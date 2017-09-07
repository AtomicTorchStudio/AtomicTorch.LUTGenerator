# LUTGenerator
This simple C# console application produces an identity 3D LUT of any specified size unwrapped as a stripe texture in the lossless PNG image format (RGB 24 bit).
The resulting 3D LUT is verified to be 100% correct.
It was a problem for me to find a 100% correct identity 32x32x32 LUT (unwrapped as 1024x32) online so I wrote this application.

There are already generated identity 3D LUT textures in the [LUT folder](/GeneratedLUT/) so you don't necessary need to run this application for common sizes of LUT textures.

Examples:   
![16x16x16 3D LUT unwrapped as 16x256 texture](/GeneratedLUT/LUT16.png)
![32x32x32 3D LUT unwrapped as 32x1024 texture](/GeneratedLUT/LUT32.png)

Learn more about 3D LUT and its application for color grading in video games:
* https://docs.unrealengine.com/latest/INT/Engine/Rendering/PostProcessEffects/ColorGrading/
* https://docs.unity3d.com/550/Documentation/Manual/script-ColorCorrectionLookup.html

Application requirements: .NET Framework 4.0 (client profile).
Build requirements: Visual Studio 2015 or newer.

MIT License.
