CHINESE MOUNTAINS - PARALLAX BACKGROUND FOR UNITY
=================================================

CONTENTS
  Backgrounds/<theme>/   ink, dawn, day, dusk, night (same layout in each)
    00_sky.png           1920x1080, static (gradient + sun/moon/stars)
    01_clouds.png        3840x1080, tiles horizontally
    02_far_peaks.png     3840x1080, tiles horizontally
    03_mist_far.png      3840x1080, tiles
    04_mid_peaks.png     3840x1080, tiles (pagoda)
    05_mist_mid.png      3840x1080, tiles
    06_near_ridge.png    3840x1080, tiles (pavilion)
    07_mist_near.png     3840x1080, tiles
    08_foreground.png    3840x1080, tiles
    cranes_sheet_8f.png  1024x96, 8 flap frames of 128x96 (optional sprite)
  Scripts/ParallaxBackground.cs

All layers are transparent PNGs and tile seamlessly left-to-right.

TEXTURE IMPORT SETTINGS (select all PNGs in the Inspector)
  Texture Type ........ Sprite (2D and UI)
  Pixels Per Unit ..... 100
  Mesh Type ........... Full Rect        <-- required for tiling
  Wrap Mode ........... Repeat
  Filter Mode ......... Bilinear
  Compression ......... None (or High Quality)
  Max Size ............ 4096              <-- default 2048 would downscale
  For cranes_sheet_8f.png: Sprite Mode = Multiple, slice Grid By Cell Size 128x96.

CAMERA
  Orthographic, Size 5.4 fits the 1080px-tall layers exactly at PPU 100.
  For a smaller view (e.g. Size 4), raise PPU to ~135 instead.

SETUP
  1. Create an empty GameObject "Background", add ParallaxBackground.
  2. Set Layers size to 9 and fill them in this order (back to front):

     Layer             scrollSpeed   autoScroll   tileHorizontally
     00_sky            0.00          0            off
     01_clouds         0.04          0.30         on
     02_far_peaks      0.10          0            on
     03_mist_far       0.14          0.10         on
     04_mid_peaks      0.22          0            on
     05_mist_mid       0.30          0.15         on
     06_near_ridge     0.45          0            on
     07_mist_near      0.60          0.20         on
     08_foreground     0.85          0            on

  3. Make sure your gameplay sprites use a higher Order in Layer than -92
     (backgrounds occupy -100 to -92 by default, change baseSortingOrder if needed).

  scrollSpeed = how much of the camera's movement shows up on screen.
  Higher = closer to the viewer. Your ground/gameplay plane is 1.0.

SWITCHING THEMES
  Swap the sprites in the Layers list (or keep all five sets and assign by script).
