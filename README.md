# <img src="https://raw.githubusercontent.com/djfoxer/VisualStudioMakeTheSound/master/Shared\/Resources/MakeTheSound.ico" width="100" height="100" /> Make The Sound
#### Extension for Visual Studio

Make The Sound is an extension for Visual Studio that adds sounds to your IDE.  
Currently extension adds audio warnings for this events:
- save (floppy disk sound effect)
- save all (floppy disk sound effect, longer)
- build failed (cartoon record scratch sound effect)
- build succeeded (checkpoint sound effect from vintage games)
- breakpoint hits while debugging (arrow hits target, cartoon sound effect)
- building (oldschool disk read, low sound volume)
- exception (failed sound effect from cartoon)

All sound effects can be enabled/disabled in options window:  

<img src="https://raw.githubusercontent.com/djfoxer/VisualStudioMakeTheSound/master/Images/optionsDialog.PNG" />

Links to Visual Studio Marketplace: 
- [Make The Sound](https://marketplace.visualstudio.com/items?itemName=djfoxer.MakeTheSound) for Visual Studio 2022
- [Make The Sound Legacy](https://marketplace.visualstudio.com/items?itemName=djfoxer.MakeTheSoundLegacy) for Visual Studio 2019 and older

Feel free to add your feedback here: [Issues](https://github.com/djfoxer/VisualStudioMakeTheSound/issues)

#### Changelog:

**0.3.0**
- added Visual Studio 2022 support [#6](https://github.com/djfoxer/VisualStudioMakeTheSound/issues/6)

**0.2.2**
- fix breakpoint sound [#2](https://github.com/djfoxer/VisualStudioMakeTheSound/issues/2)

**0.2.1**
- new sounds effects:
  * breakpoint hits while debugging
  * build succeeded
  * building
  * exception
- configuration window
- reduced size of the audio files

**0.1.0**
- init commit
- 3 sound events: *save*, *save all* and *build fails*
