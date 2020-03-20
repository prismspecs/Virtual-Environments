# Week 10 (3/24 & 3/26)

## Shaders

**Important Note:** Make sure that when you create a new project you select Universal RP as the project type. This enables the new Universal Render Pipeline which includes ShaderGraph shaders, the node-based scripting language within Unity for creating Shaders. Universal RP or URP is a "light weight" rendering pipeline that has lots of bells and whistles. Its counterpart, HDRP or High Definition Render Pipeline, is for high-end graphics with requisite hardware. URP will come to be the standard project type in the future.

A shader is a small program containing instructions for the GPU. They describe how to calculate the onscreen color of a particular material.

Though Unity provides a Standard Shader, sometimes you may need to make an effect beyond what the out-of-the-box shader can do.

Historically, this has required a special shading language, such as Cg or HLSL, with conventions a bit different than typical gameplay scripting. For many, shader writing is a neglected area of game development, simply because of the extra learning curve involved.

Unity introduced Shader Graph to allow you to more easlily write shaders, with minimal to no coding. Best of all, Shader Graph makes it easy to get started with a visual, interactive interface. 

### Shader Graph types

A PBR Graph can be thought of as a
A Sub Graph is a special type of Shader Graph, which you can reference from inside other graphs. This is useful when you wish to perform the same operations multiple times in one graph or across multiple graphs.

## Acknowledgements

Some helpful resources I used in researching this:
+ https://www.raywenderlich.com/3744978-shader-graph-in-unity-for-beginners
