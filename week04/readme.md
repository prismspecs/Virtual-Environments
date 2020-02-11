## Lighting

+ Blender
  + Create cube with reversed normals
  + Normals
  + Overlays -> Normals
  + Mesh -> Normals -> Flip

+ Unity

  + Based on [Brackey's Unity Lighting Tutorial](https://www.youtube.com/watch?v=VnG2gOKV9dw)

  + Disabling/Enabling Scene Lighting
  + Delete Directional Light
  + Create a plane
  + Create Material, drag to plane
  + Enable Emission, choose Color, change emission to 1.5

  + Enable static for all objects in the scene

  + Duplicate the light source, create another color material, etc.

  + Import 3d model to scene
  + Lighting is not applied, you must Generate Lightmap UVs on the model

  + Project Settings -> Lighting
  + Remove Lightbox
  + Adjust Default Ambient color to black
  + Disable Realtime Global Illumination
  + Change Lightmapper to Progressive (GPU if possible)
  + The Materials must also be changed to Baked Global Illumination
  + Compress/uncompress lightmap

  + Take a look at the Baked Lightmap image

  + Adjust direct/indirect samples and bounces

+ Exercise
  + [Using Dan Flavin as inspiration](https://www.google.com/search?q=dan+flavin&client=firefox-b-1-d&sxsrf=ACYBGNQ18WydoNyDpZm7eXDOTfwmXOGQMA:1581439395651&source=lnms&tbm=isch&sa=X&ved=2ahUKEwj7lqXr-MnnAhUIo1kKHZXDDNkQ_AUoAXoECBUQAw&biw=1536&bih=750) construct a space-based art piece that uses light to create affect but also call attention to the environment that contains it

+ [Post Processing](https://github.com/Unity-Technologies/PostProcessing) plugin


+ Projects
  + [Julian Oliver - LevelHead](https://vimeo.com/1320756)
  + [Kaho Abe - Hit Me!](https://kahoabe.net/portfolio/hit-me/)
