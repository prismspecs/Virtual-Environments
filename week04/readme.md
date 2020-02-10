## Lighting

+ Blender
  + Create cube with reversed normals
  + Normals
  + Overlays -> Normals
  + Mesh -> Normals -> Flip

+ Unity
  + [Download Yoda](https://www.thingiverse.com/thing:276994)
  + Disabling/Enabling Scene Lighting
  + Delete Directional Light
  + Create a plane
  + Create Material, drag to plane
  + Enable Emission, choose Color, change emission to 1.5

  + Enable static for all objects in the scene

  + Duplicate the light source, create another color material, etc.

  + Import Yoda to scene
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




+ Projects
  + [Julian Oliver - LevelHead](https://vimeo.com/1320756)
  + [Kaho Abe - Hit Me!](https://kahoabe.net/portfolio/hit-me/)
