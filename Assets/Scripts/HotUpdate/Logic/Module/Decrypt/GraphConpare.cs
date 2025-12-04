using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class SimilarityResult
{
    public double OverallSimilarity { get; set; }
    public double GlobalSimilarity { get; set; }
    public double RegionalSimilarity { get; set; }
    public double LocalSimilarity { get; set; }
    public double HausdorffSimilarity { get; set; }
    public double FeatureSimilarity { get; set; }

    public void ShowResult()
    {
        Debug.Log($"整体相似度: {OverallSimilarity:P2}\n" +
               $"全局形状: {GlobalSimilarity:P2}\n" +
               $"区域特征: {RegionalSimilarity:P2}\n" +
               $"局部细节: {LocalSimilarity:P2}\n" +
               $"Hausdorff: {HausdorffSimilarity:P2}\n" +
               $"特征匹配: {FeatureSimilarity:P2}");
    }
}

public class ComprehensiveShapeSimilarity : Singleton<ComprehensiveShapeSimilarity>
{
    private const int MAX_POINTS = 1000;
    private const int CONTOUR_POINTS = 256;
    private const int GRID_SIZE = 32;
    private const float EPSILON = 0.0001f; // 添加小量避免除以零

    public SimilarityResult CompareShapes(List<Vector3> points1, List<Vector3> points2)
    {
        var result = new SimilarityResult();

        // 检查输入数据
        if (points1 == null || points2 == null || points1.Count == 0 || points2.Count == 0)
        {
            Debug.LogWarning("输入点云数据为空或null");
            return CreateDefaultResult();
        }

        try
        {
            // 预处理点云
            var processed1 = PreprocessPoints(points1);
            var processed2 = PreprocessPoints(points2);

            // 检查预处理后的数据
            if (processed1.Count == 0 || processed2.Count == 0)
            {
                Debug.LogWarning("预处理后的点云数据为空");
                return CreateDefaultResult();
            }

            // 并行计算各种相似度
            var tasks = new System.Threading.Tasks.Task<double>[]
            {
                System.Threading.Tasks.Task.Run(() => CalculateGlobalSimilarity(processed1, processed2)),
                System.Threading.Tasks.Task.Run(() => CalculateRegionalSimilarity(processed1, processed2)),
                System.Threading.Tasks.Task.Run(() => CalculateLocalSimilarity(processed1, processed2)),
                System.Threading.Tasks.Task.Run(() => CalculateHausdorffSimilarity(processed1, processed2)),
                System.Threading.Tasks.Task.Run(() => CalculateFeatureSimilarity(processed1, processed2))
            };

            System.Threading.Tasks.Task.WaitAll(tasks);

            // 检查并处理NaN值
            result.GlobalSimilarity = ValidateValue(tasks[0].Result);
            result.RegionalSimilarity = ValidateValue(tasks[1].Result);
            result.LocalSimilarity = ValidateValue(tasks[2].Result);
            result.HausdorffSimilarity = ValidateValue(tasks[3].Result);
            result.FeatureSimilarity = ValidateValue(tasks[4].Result);

            // 加权综合评分
            result.OverallSimilarity = CalculateOverallSimilarity(result);
        }
        catch (Exception e)
        {
            Debug.LogError($"形状相似度计算错误: {e.Message}");
            return CreateDefaultResult();
        }

        return result;
    }

    private SimilarityResult CreateDefaultResult()
    {
        return new SimilarityResult
        {
            OverallSimilarity = 0,
            GlobalSimilarity = 0,
            RegionalSimilarity = 0,
            LocalSimilarity = 0,
            HausdorffSimilarity = 0,
            FeatureSimilarity = 0
        };
    }

    private double ValidateValue(double value)
    {
        if (double.IsNaN(value) || double.IsInfinity(value))
            return 0;
        return Math.Max(0, Math.Min(1, value)); // 确保值在0-1范围内
    }

    private List<Vector3> PreprocessPoints(List<Vector3> points)
    {
        if (points == null || points.Count == 0)
            return new List<Vector3>();

        try
        {
            // 1. 降采样
            var sampled = DownsamplePoints(points, MAX_POINTS);

            // 2. 平滑滤波
            var smoothed = SmoothPoints(sampled, 3);

            // 3. 归一化
            var normalized = NormalizePoints(smoothed);

            return normalized;
        }
        catch (Exception e)
        {
            Debug.LogError($"点云预处理错误: {e.Message}");
            return points.Take(Math.Min(points.Count, MAX_POINTS)).ToList();
        }
    }

    private List<Vector3> DownsamplePoints(List<Vector3> points, int targetCount)
    {
        if (points.Count <= targetCount)
            return new List<Vector3>(points);

        try
        {
            float cellSize = CalculateOptimalCellSize(points, targetCount);
            if (cellSize < EPSILON)
            {
                // 如果计算出的cellSize太小，使用简单随机采样
                return SimpleRandomSample(points, targetCount);
            }

            var grid = new Dictionary<string, List<Vector3>>();

            foreach (var point in points)
            {
                string cellKey = $"{(int)(point.x / cellSize)}-{(int)(point.y / cellSize)}-{(int)(point.z / cellSize)}";
                if (!grid.ContainsKey(cellKey))
                    grid[cellKey] = new List<Vector3>();
                grid[cellKey].Add(point);
            }

            var result = new List<Vector3>();
            foreach (var cell in grid.Values)
            {
                Vector3 center = CalculateCentroid(cell);
                result.Add(center);

                if (result.Count >= targetCount)
                    break;
            }

            // 如果网格数量不足，补充随机点
            if (result.Count < targetCount)
            {
                result.AddRange(SimpleRandomSample(points, targetCount - result.Count));
            }

            return result;
        }
        catch (Exception e)
        {
            Debug.LogError($"降采样错误: {e.Message}");
            return SimpleRandomSample(points, targetCount);
        }
    }

    private List<Vector3> SimpleRandomSample(List<Vector3> points, int targetCount)
    {
        if (points.Count <= targetCount)
            return new List<Vector3>(points);

        var random = new System.Random();
        return points.OrderBy(x => random.Next()).Take(targetCount).ToList();
    }

    private List<Vector3> SmoothPoints(List<Vector3> points, int windowSize)
    {
        if (points.Count <= windowSize || windowSize <= 1)
            return new List<Vector3>(points);

        try
        {
            var smoothed = new List<Vector3>();
            int halfWindow = windowSize / 2;

            for (int i = 0; i < points.Count; i++)
            {
                int start = Math.Max(0, i - halfWindow);
                int end = Math.Min(points.Count - 1, i + halfWindow);

                Vector3 sum = Vector3.zero;
                int count = 0;

                for (int j = start; j <= end; j++)
                {
                    sum += points[j];
                    count++;
                }

                smoothed.Add(sum / count);
            }

            return smoothed;
        }
        catch (Exception e)
        {
            Debug.LogError($"平滑滤波错误: {e.Message}");
            return new List<Vector3>(points);
        }
    }

    private List<Vector3> NormalizePoints(List<Vector3> points)
    {
        if (points.Count == 0)
            return new List<Vector3>();

        try
        {
            // 计算重心
            Vector3 centroid = CalculateCentroid(points);

            // 平移至原点
            var centered = points.Select(p => p - centroid).ToList();

            // 计算最大距离并缩放
            float maxDistance = centered.Max(p => p.magnitude);
            if (maxDistance > EPSILON)
            {
                return centered.Select(p => p / maxDistance).ToList();
            }

            return centered;
        }
        catch (Exception e)
        {
            Debug.LogError($"归一化错误: {e.Message}");
            return new List<Vector3>(points);
        }
    }

    private Vector3 CalculateCentroid(List<Vector3> points)
    {
        if (points.Count == 0) return Vector3.zero;

        Vector3 sum = Vector3.zero;
        foreach (var point in points)
        {
            sum += point;
        }
        return sum / points.Count;
    }

    private float CalculateOptimalCellSize(List<Vector3> points, int targetCount)
    {
        if (points.Count == 0) return 1.0f;

        try
        {
            float minX = points.Min(p => p.x);
            float maxX = points.Max(p => p.x);
            float minY = points.Min(p => p.y);
            float maxY = points.Max(p => p.y);
            float minZ = points.Min(p => p.z);
            float maxZ = points.Max(p => p.z);

            float volume = (maxX - minX) * (maxY - minY) * (maxZ - minZ);
            if (volume <= 0) return 0.1f;

            float targetCellVolume = volume / targetCount;
            return Math.Max(0.01f, (float)Math.Pow(targetCellVolume, 1.0 / 3.0));
        }
        catch (Exception e)
        {
            Debug.LogError($"计算网格尺寸错误: {e.Message}");
            return 0.1f;
        }
    }

    // 全局形状相似度
    private double CalculateGlobalSimilarity(List<Vector3> points1, List<Vector3> points2)
    {
        if (points1.Count == 0 || points2.Count == 0) return 0;

        try
        {
            var similarities = new List<double>();

            // 1. 边界框相似度
            similarities.Add(CompareBoundingBoxes(points1, points2));

            // 2. 主方向相似度
            similarities.Add(ComparePrincipalDirections(points1, points2));

            // 3. 紧密度相似度
            similarities.Add(CompareCompactness(points1, points2));

            return similarities.Count > 0 ? similarities.Average() : 0;
        }
        catch (Exception e)
        {
            Debug.LogError($"全局相似度计算错误: {e.Message}");
            return 0;
        }
    }

    // 区域特征相似度
    private double CalculateRegionalSimilarity(List<Vector3> points1, List<Vector3> points2)
    {
        if (points1.Count == 0 || points2.Count == 0) return 0;

        try
        {
            var density1 = CalculateDensityDistribution(points1, GRID_SIZE);
            var density2 = CalculateDensityDistribution(points2, GRID_SIZE);

            return CosineSimilarity(density1, density2);
        }
        catch (Exception e)
        {
            Debug.LogError($"区域相似度计算错误: {e.Message}");
            return 0;
        }
    }

    // 局部细节相似度
    private double CalculateLocalSimilarity(List<Vector3> points1, List<Vector3> points2)
    {
        if (points1.Count == 0 || points2.Count == 0) return 0;

        try
        {
            var keypoints1 = DetectKeypoints(points1, 50);
            var keypoints2 = DetectKeypoints(points2, 50);

            if (keypoints1.Count == 0 || keypoints2.Count == 0) return 0.5; // 无法提取关键点时返回中间值

            var descriptors1 = ComputeLocalDescriptors(points1, keypoints1);
            var descriptors2 = ComputeLocalDescriptors(points2, keypoints2);

            return MatchLocalFeatures(descriptors1, descriptors2);
        }
        catch (Exception e)
        {
            Debug.LogError($"局部相似度计算错误: {e.Message}");
            return 0;
        }
    }

    // Hausdorff相似度
    private double CalculateHausdorffSimilarity(List<Vector3> points1, List<Vector3> points2)
    {
        if (points1.Count == 0 || points2.Count == 0) return 0;

        try
        {
            double distance1 = CalculateDirectedHausdorff(points1, points2);
            double distance2 = CalculateDirectedHausdorff(points2, points1);
            double hausdorffDistance = Math.Max(distance1, distance2);

            // 转换为相似度 (0-1)，使用更稳定的转换
            return Math.Exp(-hausdorffDistance * 5); // 减少系数避免过小
        }
        catch (Exception e)
        {
            Debug.LogError($"Hausdorff相似度计算错误: {e.Message}");
            return 0;
        }
    }

    // 特征匹配相似度
    private double CalculateFeatureSimilarity(List<Vector3> points1, List<Vector3> points2)
    {
        if (points1.Count == 0 || points2.Count == 0) return 0;

        try
        {
            var features1 = ExtractShapeFeatures(points1);
            var features2 = ExtractShapeFeatures(points2);

            return CompareShapeFeatures(features1, features2);
        }
        catch (Exception e)
        {
            Debug.LogError($"特征相似度计算错误: {e.Message}");
            return 0;
        }
    }

    // 辅助方法实现
    private double CompareBoundingBoxes(List<Vector3> points1, List<Vector3> points2)
    {
        var bbox1 = CalculateBoundingBox(points1);
        var bbox2 = CalculateBoundingBox(points2);

        double sizeSimilarity = 1.0 - Math.Abs(bbox1.Volume - bbox2.Volume) / (Math.Max(bbox1.Volume, bbox2.Volume) + EPSILON);
        double aspectSimilarity = CompareAspectRatios(bbox1, bbox2);

        return (sizeSimilarity + aspectSimilarity) / 2.0;
    }

    private BoundingBox CalculateBoundingBox(List<Vector3> points)
    {
        if (points.Count == 0)
            return new BoundingBox { Volume = EPSILON };

        float minX = points.Min(p => p.x);
        float maxX = points.Max(p => p.x);
        float minY = points.Min(p => p.y);
        float maxY = points.Max(p => p.y);
        float minZ = points.Min(p => p.z);
        float maxZ = points.Max(p => p.z);

        float width = Math.Max(EPSILON, maxX - minX);
        float height = Math.Max(EPSILON, maxY - minY);
        float depth = Math.Max(EPSILON, maxZ - minZ);

        return new BoundingBox
        {
            Min = new Vector3(minX, minY, minZ),
            Max = new Vector3(maxX, maxY, maxZ),
            Width = width,
            Height = height,
            Depth = depth,
            Volume = width * height * depth
        };
    }

    private double CompareAspectRatios(BoundingBox bbox1, BoundingBox bbox2)
    {
        double aspect1 = bbox1.Width / Math.Max(bbox1.Height, EPSILON);
        double aspect2 = bbox2.Width / Math.Max(bbox2.Height, EPSILON);

        return 1.0 - Math.Min(Math.Abs(aspect1 - aspect2) / (Math.Max(aspect1, aspect2) + EPSILON), 1.0);
    }

    private double ComparePrincipalDirections(List<Vector3> points1, List<Vector3> points2)
    {
        var pca1 = CalculatePCA(points1);
        var pca2 = CalculatePCA(points2);

        // 比较主方向的角度差异
        double angleDiff = CalculateAngleBetweenVectors(pca1.PrincipalAxis, pca2.PrincipalAxis);

        return 1.0 - (angleDiff / Math.PI);
    }

    private PCAResult CalculatePCA(List<Vector3> points)
    {
        if (points.Count < 3)
            return new PCAResult { PrincipalAxis = Vector3.right };

        try
        {
            Vector3 centroid = CalculateCentroid(points);

            // 计算协方差矩阵
            float[,] covariance = new float[3, 3];
            for (int i = 0; i < points.Count; i++)
            {
                Vector3 diff = points[i] - centroid;
                covariance[0, 0] += diff.x * diff.x;
                covariance[0, 1] += diff.x * diff.y;
                covariance[0, 2] += diff.x * diff.z;
                covariance[1, 0] += diff.y * diff.x;
                covariance[1, 1] += diff.y * diff.y;
                covariance[1, 2] += diff.y * diff.z;
                covariance[2, 0] += diff.z * diff.x;
                covariance[2, 1] += diff.z * diff.y;
                covariance[2, 2] += diff.z * diff.z;
            }

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    covariance[i, j] /= points.Count;

            // 简化：返回最大特征值对应的特征向量（这里使用近似方法）
            Vector3 principalAxis = FindPrincipalAxis(covariance);
            return new PCAResult { PrincipalAxis = principalAxis };
        }
        catch (Exception e)
        {
            Debug.LogError($"PCA计算错误: {e.Message}");
            return new PCAResult { PrincipalAxis = Vector3.right };
        }
    }

    private Vector3 FindPrincipalAxis(float[,] covariance)
    {
        // 简化实现：使用幂迭代法求最大特征值对应的特征向量
        Vector3 v = Vector3.one;
        for (int i = 0; i < 10; i++) // 迭代10次
        {
            Vector3 newV = new Vector3(
                covariance[0, 0] * v.x + covariance[0, 1] * v.y + covariance[0, 2] * v.z,
                covariance[1, 0] * v.x + covariance[1, 1] * v.y + covariance[1, 2] * v.z,
                covariance[2, 0] * v.x + covariance[2, 1] * v.y + covariance[2, 2] * v.z
            );

            if (newV.magnitude > EPSILON)
            {
                v = newV.normalized;
            }
            else
            {
                break;
            }
        }

        return v;
    }

    private double CalculateAngleBetweenVectors(Vector3 v1, Vector3 v2)
    {
        float dot = Vector3.Dot(v1, v2);
        float len1 = v1.magnitude;
        float len2 = v2.magnitude;

        if (len1 < EPSILON || len2 < EPSILON) return 0;

        float cosAngle = dot / (len1 * len2);
        cosAngle = Math.Max(-1, Math.Min(1, cosAngle));

        return Math.Acos(cosAngle);
    }

    private double CompareCompactness(List<Vector3> points1, List<Vector3> points2)
    {
        double compactness1 = CalculateCompactness(points1);
        double compactness2 = CalculateCompactness(points2);

        return 1.0 - Math.Abs(compactness1 - compactness2);
    }

    private double CalculateCompactness(List<Vector3> points)
    {
        if (points.Count < 3) return 0;

        try
        {
            Vector3 centroid = CalculateCentroid(points);
            double avgDistance = points.Average(p => Vector3.Distance(p, centroid));

            return 1.0 / (1.0 + avgDistance);
        }
        catch (Exception e)
        {
            Debug.LogError($"紧密度计算错误: {e.Message}");
            return 0;
        }
    }

    private float[] CalculateDensityDistribution(List<Vector3> points, int gridSize)
    {
        var density = new float[gridSize * gridSize * gridSize];
        if (points.Count == 0) return density;

        try
        {
            // 找到点云范围
            var bbox = CalculateBoundingBox(points);
            float sizeX = Math.Max(bbox.Width, EPSILON);
            float sizeY = Math.Max(bbox.Height, EPSILON);
            float sizeZ = Math.Max(bbox.Depth, EPSILON);

            foreach (var point in points)
            {
                int x = (int)((point.x - bbox.Min.x) / sizeX * (gridSize - 1));
                int y = (int)((point.y - bbox.Min.y) / sizeY * (gridSize - 1));
                int z = (int)((point.z - bbox.Min.z) / sizeZ * (gridSize - 1));

                x = Math.Max(0, Math.Min(gridSize - 1, x));
                y = Math.Max(0, Math.Min(gridSize - 1, y));
                z = Math.Max(0, Math.Min(gridSize - 1, z));

                int index = x * gridSize * gridSize + y * gridSize + z;
                density[index] += 1.0f / points.Count;
            }

            return density;
        }
        catch (Exception e)
        {
            Debug.LogError($"密度分布计算错误: {e.Message}");
            return density;
        }
    }

    private double CosineSimilarity(float[] vec1, float[] vec2)
    {
        if (vec1.Length != vec2.Length) return 0;

        try
        {
            double dotProduct = 0;
            double magnitude1 = 0;
            double magnitude2 = 0;

            for (int i = 0; i < vec1.Length; i++)
            {
                dotProduct += vec1[i] * vec2[i];
                magnitude1 += vec1[i] * vec1[i];
                magnitude2 += vec2[i] * vec2[i];
            }

            magnitude1 = Math.Sqrt(magnitude1);
            magnitude2 = Math.Sqrt(magnitude2);

            if (magnitude1 < EPSILON || magnitude2 < EPSILON)
                return 0;

            double similarity = dotProduct / (magnitude1 * magnitude2);
            return Math.Max(0, Math.Min(1, similarity)); // 确保在0-1范围内
        }
        catch (Exception e)
        {
            Debug.LogError($"余弦相似度计算错误: {e.Message}");
            return 0;
        }
    }

    private List<Vector3> DetectKeypoints(List<Vector3> points, int maxKeypoints)
    {
        // 简化实现：均匀采样关键点
        var keypoints = new List<Vector3>();
        if (points.Count == 0) return keypoints;

        try
        {
            int step = Math.Max(1, points.Count / maxKeypoints);

            for (int i = 0; i < points.Count && keypoints.Count < maxKeypoints; i += step)
            {
                keypoints.Add(points[i]);
            }

            return keypoints;
        }
        catch (Exception e)
        {
            Debug.LogError($"关键点检测错误: {e.Message}");
            return points.Take(Math.Min(points.Count, maxKeypoints)).ToList();
        }
    }

    private List<float[]> ComputeLocalDescriptors(List<Vector3> points, List<Vector3> keypoints)
    {
        var descriptors = new List<float[]>();

        try
        {
            foreach (var keypoint in keypoints)
            {
                // 简化描述符：关键点周围的点密度分布
                var descriptor = new float[27]; // 3x3x3网格
                int index = 0;

                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        for (int dz = -1; dz <= 1; dz++)
                        {
                            Vector3 testPoint = new Vector3(
                                keypoint.x + dx * 0.1f,
                                keypoint.y + dy * 0.1f,
                                keypoint.z + dz * 0.1f
                            );

                            // 计算该区域内的点数量
                            int count = points.Count(p => Vector3.Distance(p, testPoint) < 0.15f);
                            descriptor[index++] = count / (float)Math.Max(points.Count, 1);
                        }
                    }
                }

                descriptors.Add(descriptor);
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"局部描述符计算错误: {e.Message}");
        }

        return descriptors;
    }

    private double MatchLocalFeatures(List<float[]> descriptors1, List<float[]> descriptors2)
    {
        if (descriptors1.Count == 0 || descriptors2.Count == 0) return 0;

        try
        {
            double totalSimilarity = 0;
            int matches = 0;

            foreach (var desc1 in descriptors1)
            {
                double bestSimilarity = 0;

                foreach (var desc2 in descriptors2)
                {
                    double similarity = CosineSimilarity(desc1, desc2);
                    if (similarity > bestSimilarity)
                    {
                        bestSimilarity = similarity;
                    }
                }

                totalSimilarity += bestSimilarity;
                matches++;
            }

            return matches > 0 ? totalSimilarity / matches : 0;
        }
        catch (Exception e)
        {
            Debug.LogError($"局部特征匹配错误: {e.Message}");
            return 0;
        }
    }

    private double CalculateDirectedHausdorff(List<Vector3> setA, List<Vector3> setB)
    {
        if (setA.Count == 0 || setB.Count == 0) return double.MaxValue;

        try
        {
            double maxMinDistance = 0;

            foreach (var pointA in setA)
            {
                double minDistance = double.MaxValue;
                foreach (var pointB in setB)
                {
                    double distance = Vector3.Distance(pointA, pointB);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                    }
                }
                if (minDistance > maxMinDistance)
                {
                    maxMinDistance = minDistance;
                }
            }

            return maxMinDistance;
        }
        catch (Exception e)
        {
            Debug.LogError($"定向Hausdorff距离计算错误: {e.Message}");
            return double.MaxValue;
        }
    }

    private ShapeFeatures ExtractShapeFeatures(List<Vector3> points)
    {
        return new ShapeFeatures
        {
            Area = CalculateArea(points),
            Perimeter = CalculatePerimeter(points),
            Volume = CalculateVolume(points),
            Eccentricity = CalculateEccentricity(points)
        };
    }

    private double CompareShapeFeatures(ShapeFeatures f1, ShapeFeatures f2)
    {
        try
        {
            double areaSim = 1.0 - Math.Abs(f1.Area - f2.Area) / (Math.Max(f1.Area, f2.Area) + EPSILON);
            double perimeterSim = 1.0 - Math.Abs(f1.Perimeter - f2.Perimeter) / (Math.Max(f1.Perimeter, f2.Perimeter) + EPSILON);
            double volumeSim = 1.0 - Math.Abs(f1.Volume - f2.Volume) / (Math.Max(f1.Volume, f2.Volume) + EPSILON);
            double eccentricitySim = 1.0 - Math.Min(Math.Abs(f1.Eccentricity - f2.Eccentricity), 1.0);

            return (areaSim + perimeterSim + volumeSim + eccentricitySim) / 4.0;
        }
        catch (Exception e)
        {
            Debug.LogError($"形状特征比较错误: {e.Message}");
            return 0;
        }
    }

    private double CalculateArea(List<Vector3> points)
    {
        if (points.Count < 3) return 0;

        try
        {
            // 使用边界框面积作为近似
            var bbox = CalculateBoundingBox(points);
            return bbox.Width * bbox.Height;
        }
        catch (Exception e)
        {
            Debug.LogError($"面积计算错误: {e.Message}");
            return 0;
        }
    }

    private double CalculatePerimeter(List<Vector3> points)
    {
        if (points.Count < 2) return 0;

        try
        {
            // 计算点云边界长度
            double perimeter = 0;
            for (int i = 0; i < points.Count; i++)
            {
                int next = (i + 1) % points.Count;
                perimeter += Vector3.Distance(points[i], points[next]);
            }

            return perimeter;
        }
        catch (Exception e)
        {
            Debug.LogError($"周长计算错误: {e.Message}");
            return 0;
        }
    }

    private double CalculateVolume(List<Vector3> points)
    {
        try
        {
            var bbox = CalculateBoundingBox(points);
            return bbox.Volume;
        }
        catch (Exception e)
        {
            Debug.LogError($"体积计算错误: {e.Message}");
            return 0;
        }
    }

    private double CalculateEccentricity(List<Vector3> points)
    {
        try
        {
            var bbox = CalculateBoundingBox(points);
            if (bbox.Height < EPSILON) return 0;

            return bbox.Width / bbox.Height;
        }
        catch (Exception e)
        {
            Debug.LogError($"偏心率计算错误: {e.Message}");
            return 0;
        }
    }

    private double CalculateOverallSimilarity(SimilarityResult result)
    {
        // 加权综合评分
        return result.GlobalSimilarity * 0.25 +
               result.RegionalSimilarity * 0.25 +
               result.LocalSimilarity * 0.20 +
               result.HausdorffSimilarity * 0.15 +
               result.FeatureSimilarity * 0.15;
    }
}

// 辅助类
[Serializable]
public class BoundingBox
{
    public Vector3 Min { get; set; }
    public Vector3 Max { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }
    public float Depth { get; set; }
    public float Volume { get; set; }
}

[Serializable]
public class PCAResult
{
    public Vector3 PrincipalAxis { get; set; }
}

[Serializable]
public class ShapeFeatures
{
    public double Area { get; set; }
    public double Perimeter { get; set; }
    public double Volume { get; set; }
    public double Eccentricity { get; set; }
}
