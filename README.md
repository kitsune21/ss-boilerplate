# ss-boilerplate
My own boilerplate for Unity Projects, with prefabs, and generic controllers already built (such as music, sound, character, etc).

# Character Controllers
Default player character controllers.

## TopDown
This is for Zelda-like movement.

# Clip Script
This is the ScriptableObject for soundfx and songs. Simply give it a name and an auido clip and the sound and music controllers can handle the rest.

# Sound Controller
This Game Controller handles the sound fx. It has a list of ClipScripts. You just need to call the playEffect() function and as long as their is a ClipScript (from the list) that has a name that matches it will play the effect. It will scale up the number of audio sources to match the number of effects that need to be played.

# Music Controller
This Game Controller handles the music. To play a clip you can call loopClip() or fadeInClip(), depending on your needs. The stopClip() and endLoop() functions are also available.

# UI Prefabs

## Defaultable Text
This object will save a reference to it's initial text, and then when calling the updateText function it will display the default text, plus the new text.

## Credits Panel
1. Add the CreditPanel Prefab to your canvas.
2. Add the "CategoryTitle" and "PersonText" to the CreditPanel script (adjust font, size, color, etc as needed)
3. Create a "Person" scriptable object, use their first name for filename.
4. Input their full name ("John Smith")
5. Select their category from the dropdown.
6. Add the created person to the "People" list.

As a note, if someone needs to be added to multiple categories, please create multiple person objects.
