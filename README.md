# TaskRapsodo

## Introduction
This project is a task for Rapsodo. It features a 3D world set in a forest environment. Players can move using basic WASD controls and look around using the mouse. The environment is designed with various objects, including trees, rocks, and grasses, to create an immersive experience.

## Installation
This project was developed using **Unity 2021.3.44f1**. To run the project, ensure you have this version or a compatible version of Unity installed.

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
