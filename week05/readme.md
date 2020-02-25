# Week 5 (2/18 & 2/20)

+ Project 1 Presentations (2/18)

## Twine Workshop
+ You can use either the web app or the native application. Note that work is automatically saved in Documents/Stories folder if using the native application, and in browser cache if using the web app
+ Helpful links & continued learning
  + [Twinery - Official Website](https://twinery.org/)
  + [Twine 2 Harlowe Scripting Guide](https://twine2.neocities.org/)
  + [Twine 2 YouTube tutorial](https://www.youtube.com/watch?v=iKFZhIHD7Xk)
    + [Adding background images](https://www.youtube.com/watch?v=T2xl9JaGqpM)
  + [Datamaps (advanced)](https://www.youtube.com/watch?v=NZroyIYTk2k&list=PLFgjYYTq6xyjBtXJTvEaBTVUWxirY6q24)

### Basics
+ Passages
+ Start Story
+ Links
  + Link text vs passage name
  + ```[[Some story text the player will see->PassageName]]```
+ Styling CSS
  + [View template](twine.css)
+ Adding images/arbitrary HTML
  + HTML to add an image```<img src="url.jpg">```
  + CSS to scale images to browser window size```img { max-width:100%; }```
+ Save/load game
  + ```(link:"Save game")[(save-game:"Slot A")]```
  + ```(link:"Load game")[(load-game:"Slot A")]```
+ Hide sidebar
  + ```tw-sidebar { visibility: hidden }```

+ Blender -> Mixamo -> Unity & Basic Character Animation scripting
  + [Follow along with instructions here](mixamo-to-unity.md)

+ Projects
  + [The Secret of Monkey Island](https://playclassic.games/games/point-n-click-adventure-dos-games-online/play-secret-monkey-island-online/)
  + [Nicky Case - Coming Out Simulator](https://ncase.itch.io/coming-out-simulator-2014)
