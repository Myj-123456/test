var MyPlugin = {
  // 获取URL查询参数（原有功能）
  GetQuerySearch: function() {
    var returnStr = window.location.search;
    var bufferSize = lengthBytesUTF8(returnStr) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(returnStr, buffer, bufferSize);
    return buffer;
  },

  // 保存字符串到 localStorage
  SaveToLocalStorage: function(keyPtr, valuePtr) {
    try {
      var key = UTF8ToString(keyPtr);
      var value = UTF8ToString(valuePtr);
      localStorage.setItem(key, value);
      return 1; // 成功
    } catch (e) {
      return 0; // 失败
    }
  },

  // 从 localStorage 读取字符串
  LoadFromLocalStorage: function(keyPtr) {
    try {
      var key = UTF8ToString(keyPtr);
      var value = localStorage.getItem(key);
      var bufferSize = lengthBytesUTF8(value) + 1;
      var buffer = _malloc(bufferSize);
      stringToUTF8(value, buffer, bufferSize);
      return buffer;
    } catch (e) {
      
    }
  },

  // 从 localStorage 删除键
  RemoveFromLocalStorage: function(keyPtr) {
    try {
      var key = UTF8ToString(keyPtr);
      localStorage.removeItem(key);
      return 1; // 成功
    } catch (e) {
      console.error('RemoveFromLocalStorage error:', e);
      return 0; // 失败
    }
  },

  // 检查 localStorage 中是否存在某个键
  HasKeyInLocalStorage: function(keyPtr) {
    try {
      var key = UTF8ToString(keyPtr);
      return localStorage.getItem(key) !== null ? 1 : 0;
    } catch (e) {
      return 0; // 失败
    }
  },

  // 清空所有 localStorage 数据（危险操作，慎用）
  ClearLocalStorage: function() {
    try {
      localStorage.clear();
      return 1; // 成功
    } catch (e) {
      return 0; // 失败
    }
  }
};

mergeInto(LibraryManager.library, MyPlugin);