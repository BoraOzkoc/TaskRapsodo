# TaskRapsodo

## Introduction
This project is a task for Rapsodo. It features a 3D world set in a forest environment. Players can move using basic WASD controls and look around using the mouse. The environment is designed with various objects, including trees, rocks, and grasses, to create an immersive experience.

## Installation

1. **Clone the Repository:**
   - Clone the project.
   - Navigate to the directory where you want to clone the project.

2. **Open the Project in Unity:**
   - Launch **Unity Hub**.
   - Click on **Add** to select the cloned project folder.
   - Make sure to open the project with **Unity 2021.3.44f1** or a compatible version.

3. **Import Required Packages:**
   - In the Unity editor, go to **Window > Package Manager**.
   - Ensure the following package is imported:
     - **Lowpoly Environment - Nature Free - MEDIEVAL FANTASY SERIES**

4. **Setup the Scene:**
   - Open the main scene and ensure all required assets are in place.
   - Configure any settings as needed to match your desired gameplay experience.

## Project Type
- **Unity Render Pipeline (URP)**: This choice simplifies lighting calculations and positively impacts performance.

## Static Objects
- **Trees, Rocks, and Vegetation**: These objects are set as static to reduce the load by selecting objects that do not move.

## Movement Selection
- **Character Controller**: This was chosen over Translate because it effectively handles necessary physics calculations while maintaining optimal performance.

## Camera Settings
- **Occlusion Culling**: Improves performance by not rendering objects that are not visible.
- **Clipping Planes**: Adjusted to enhance rendering efficiency.

## Lighting
- **Baked Mode**: Pre-computed lighting is used to enhance performance.

## Environment Features
- **Detail Distance and Tree Distance**: Set to optimize the rendering of distant objects.
- **Triangles Reduced by 50% (500k)**: Minimizes the graphical load.

## Performance Optimizations
- **LOD (Level of Detail) Groups**: Utilized to transition between simpler and more complex meshes based on distance for trees, rocks, and grasses.
  - **Rocks**: Implemented LOD Groups with Box Colliders instead of Mesh Colliders for better performance.
  - **Grasses**: LOD Groups are used for performance optimization.
  - **Trees**: Low poly models were selected to reduce vertex counts, and a single-material model was used.
- **Texture Optimization**: Utilized Crunch Compression to reduce texture sizes.
- **Mesh Optimization**: Applied Mesh Compression for enhanced performance.
