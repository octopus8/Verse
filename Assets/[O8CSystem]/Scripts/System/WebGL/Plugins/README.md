# WebGL Plugins Directory

## Assembly Definition
Added to:
* Assets/Oculus/LipSync/Oculus.LipSync.asmdef


## Microphone Directory
* Source: https://github.com/tgraupmann/UnityWebGLMicrophone
* Added to allow the project to compile for WebGL while including the Oculus Integration package.
* I'm not sure it works; the Oculus package references the "Start" and "GetPosistion" methods, which did not exist. I added stubbed versions of this.
* Another version of the Microphone class is imported from the Microphone WebGL Library. I believe this is actually used by Photon Voice
  * Source of other Microphone class: https://assetstore.unity.com/packages/tools/input-management/microphone-webgl-library-79989

