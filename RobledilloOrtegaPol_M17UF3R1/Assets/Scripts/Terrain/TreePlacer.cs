//Created by Pirani Dev and available in blacave.com/store
//TreePlacer is a tool to add trees to the terrain globally based on a texture mask.
using UnityEngine;

public class TreePlacer : MonoBehaviour
{
    public Terrain terrain;
    public int[] treePrototypeIndices; // Indices for multiple tree types (matches terrain tree prototypes)
    public float treeDensity = 100f; // Density (trees per unit area, similar to Unity's slider 0-100)
    public int selectedTextureIndex; // Index of the terrain texture to use as a mask
    public float maxHeight = 1000f; // Maximum terrain height for tree placement
    public float minHeight = 0f; // Minimum terrain height for tree placement
    public float brushSize = 40f; // Brush size (similar to Unity's brush size slider)
    public bool randomizeHeight = true; // Toggle for random height variation
    public bool randomizeWidth = true; // Toggle for random width variation
    public float heightVariation = 0.2f; // Variation range for height (e.g., ±20%)
    public float widthVariation = 0.2f; // Variation range for width (e.g., ±20%)

    void Start()
    {
        ApplyTreesUsingBrushMask();
    }

    void ApplyTreesUsingBrushMask()
    {
        TerrainData terrainData = terrain.terrainData;
        int alphamapResX = terrainData.alphamapWidth;
        int alphamapResY = terrainData.alphamapHeight;
        Vector3 terrainSize = terrainData.size;

        if (treePrototypeIndices.Length == 0)
        {
            Debug.LogError("Assign at least one tree prototype.");
            return;
        }

        // Get the alphamaps (texture layers)
        float[,,] alphamaps = terrainData.GetAlphamaps(0, 0, alphamapResX, alphamapResY);

        // Clear existing trees
        terrainData.treeInstances = new TreeInstance[0];

        // Create a new list for tree instances
        System.Collections.Generic.List<TreeInstance> newTrees = new System.Collections.Generic.List<TreeInstance>();

        // Calculate number of trees based on density and terrain area
        float area = terrainSize.x * terrainSize.z;
        int treeCount = Mathf.RoundToInt(area * (treeDensity / 1000f)); // Scale density to a reasonable number

        for (int t = 0; t < treeCount; t++)
        {
            // Random position in terrain space
            float x = Random.value;
            float z = Random.value;

            // Convert to alphamap coordinates
            int texX = Mathf.RoundToInt(x * alphamapResX);
            int texY = Mathf.RoundToInt(z * alphamapResY);

            // Ensure we are within valid bounds
            texX = Mathf.Clamp(texX, 0, alphamapResX - 1);
            texY = Mathf.Clamp(texY, 0, alphamapResY - 1);

            // Get the alpha value for the selected texture index
            float maskValue = alphamaps[texX, texY, selectedTextureIndex];

            // Check if we should place a tree based on mask and brush simulation
            if (maskValue > 0.1f && Random.value < maskValue) // Adjust threshold and probability
            {
                // Get terrain height at position
                float height = terrainData.GetHeight(Mathf.RoundToInt(x * terrainData.heightmapResolution),
                                                    Mathf.RoundToInt(z * terrainData.heightmapResolution));

                // Check if height is within acceptable range
                if (height >= minHeight && height <= maxHeight)
                {
                    // Randomly select a tree prototype
                    int treeIndex = treePrototypeIndices[Random.Range(0, treePrototypeIndices.Length)];

                    // Calculate random scale variations
                    float widthScale = randomizeWidth ? Random.Range(1f - widthVariation, 1f + widthVariation) : 1f;
                    float heightScale = randomizeHeight ? Random.Range(1f - heightVariation, 1f + heightVariation) : 1f;

                    TreeInstance tree = new TreeInstance
                    {
                        prototypeIndex = treeIndex,
                        position = new Vector3(x, height / terrainSize.y, z),
                        widthScale = widthScale,
                        heightScale = heightScale,
                        color = Color.white,
                        lightmapColor = Color.white,
                        rotation = Random.Range(0f, 360f)
                    };

                    newTrees.Add(tree);
                }
            }
        }

        // Apply trees to terrain
        terrainData.treeInstances = newTrees.ToArray();
        terrain.Flush();
    }
}