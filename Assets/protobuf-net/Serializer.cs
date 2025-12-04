
using ProtoBuf.Meta;
using System;
using System.IO;
#if !NO_GENERICS
using System.Collections.Generic;
#endif

#if FEAT_IKVM
using Type = IKVM.Reflection.Type;
using IKVM.Reflection;
#else
using System.Reflection;
#endif

namespace ProtoBuf
{
    public unsafe class PtrStream : System.IO.UnmanagedMemoryStream
    {
        public PtrStream(byte* pointer, long length) : base(pointer, length, length, System.IO.FileAccess.ReadWrite)
        {
        }

        public void Recycle(byte* pointer, long length)
        {
            this.Position = 0;
            this.Dispose();
            Initialize(pointer, length, length, System.IO.FileAccess.ReadWrite);
        }

        public void Recycle(IntPtr pointer, long length)
        {
            this.Position = 0;
            this.Dispose();
            Initialize((byte*)pointer.ToPointer(), length, length, System.IO.FileAccess.ReadWrite);
        }

        public void Recycle(byte[] pointer)
        {
            fixed (byte* p = pointer)
            {
                Recycle(p, pointer.Length);
            }
        }

    }
        /// <summary>
        /// Provides protocol-buffer serialization capability for concrete, attributed types. This
        /// is a *default* model, but custom serializer models are also supported.
        /// </summary>
        /// <remarks>
        /// Protocol-buffer serialization is a compact binary format, designed to take
        /// advantage of sparse data and knowledge of specific data types; it is also
        /// extensible, allowing a type to be deserialized / merged even if some data is
        /// not recognised.
        /// </remarks>
        public 
#if FX11
    sealed
#else
    static
#endif
        class Serializer
    {
#if FX11
        private Serializer() { } // not a static class for C# 1.2 reasons
#endif
#if !NO_RUNTIME && !NO_GENERICS

        /// <summary>
        /// Applies a protocol-buffer stream to an existing instance.
        /// </summary>
        /// <typeparam name="T">The type being merged.</typeparam>
        /// <param name="instance">The existing instance to be modified (can be null).</param>
        /// <param name="source">The binary stream to apply to the instance (cannot be null).</param>
        /// <returns>The updated instance; this may be different to the instance argument if
        /// either the original instance was null, or the stream defines a known sub-type of the
        /// original instance.</returns>
        public static object Merge(Stream source, object instance, Type t)
        {
            return RuntimeTypeModel.Default.Deserialize(source, instance, t);
        }

        /// <summary>
        /// Creates a new instance from a protocol-buffer stream
        /// </summary>
        /// <typeparam name="T">The type to be created.</typeparam>
        /// <param name="source">The binary stream to apply to the new instance (cannot be null).</param>
        /// <returns>A new, initialized instance.</returns>
        public static object Deserialize(Stream source, Type t)
        {
            return RuntimeTypeModel.Default.Deserialize(source, null, t);
        }
        public static object Deserialize(RuntimeTypeModel model, Stream source, Type t)
        {
            return model.Deserialize(source, null, t);
        }
        private static PtrStream m_msCache = null;

        public unsafe static object Deserialize(byte[] source, Type t)
        {
            return Deserialize(source, 0, source.Length, t);
        }

        public unsafe static object Deserialize(byte[] source, int start, int len, Type t)
        {
            fixed (byte* p = source)
            {
                byte* addr = p + start;
                return Deserialize(addr, len, t);
            }
        }

        public unsafe static object Deserialize(byte* source, long len, Type t)
        {
            if (m_msCache == null)
            {
                m_msCache = new PtrStream(source, len);
            }
            else
            {
                m_msCache.Recycle(source, len);
            }
            return Deserialize(m_msCache, t);
        }

        /// <summary>
        /// Writes a protocol-buffer representation of the given instance to the supplied stream.
        /// </summary>
        /// <param name="instance">The existing instance to be serialized (cannot be null).</param>
        /// <param name="destination">The destination stream to write to.</param>
        public static void Serialize(Stream destination, object instance)
        {
            if (instance != null)
            {
                RuntimeTypeModel.Default.Serialize(destination, instance);
            }
        }
        public static void Serialize(RuntimeTypeModel model, Stream destination, object instance)
        {
            if (instance != null)
            {
                model.Serialize(destination, instance);
            }
        }
#endif
        /// <summary>
        /// The field number that is used as a default when serializing/deserializing a list of objects.
        /// The data is treated as repeated message with field number 1.
        /// </summary>
        public const int ListItemTag = 1;


        /// <summary>
        /// Maps a field-number to a type
        /// </summary>
        public delegate Type TypeResolver(int fieldNumber);

        /// <summary>
        /// Releases any internal buffers that have been reserved for efficiency; this does not affect any serialization
        /// operations; simply: it can be used (optionally) to release the buffers for garbage collection (at the expense
        /// of having to re-allocate a new buffer for the next operation, rather than re-use prior buffers).
        /// </summary>
        public static void FlushPool()
        {
            BufferPool.Flush();
        }
    }
}
