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
This Game Controller handles the music. To play a clip you can call loopClip() or crossFadeClip(), depending on your needs. The stopClip() and endLoop() functions are also available.

# Dialogue Manager
This is only a basic dialogue system. It doesn't handling branching dialogue. Only simple 3 response maximum questions. To use this you need to: 
1. Create a "Dialogue" sciptable object (should be in the "Dialogues" folder for organization). 
  -Give it a name
  -Assign a character name 
2. Then create "Dialogue Sentence" scriptable objects, one per sentence.
  -Assign it a type (statement for just simple sentences, question if it can have a response)
  -The "sentence" attribute will always display first
  -If it is a question it will then show buttons below the sentence using the text from the questions[] attribute
    -Responses will be displayed when any of the question boxes are selected
3. After creating the dialogue, you just need to call the loadDialogue() funtion from the systemsController instance.

# UI Prefabs

## Defaultable Text
This object will save a reference to it's initial text, and then when calling the updateText function it will display the default text, plus the new text.

## Countdown Slider
This slider will constantly move up or down depending on the isAppreciating and isDepreciating booleans. Call the startAppreciating() or startDepreciating() functions to go either direction. Optional reset boolean can be passed to either or to have the slider reset when the slider.value = minValue or maxValue (depending on the direction needed).

## Manual Update Slider
This slider will lerp the slider.value between the currentSetValue. Just need to call setCurrentValue() with the new value and it will animate the correct direction, up or down.

## Credits Panel
1. Add the CreditPanel Prefab to your canvas.
2. Add the "CategoryTitle" and "PersonText" to the CreditPanel script (adjust font, size, color, etc as needed)
3. Create a "Person" scriptable object, use their first name for filename.
4. Input their full name ("John Smith")
5. Select their category from the dropdown.
6. Add the created person to the "People" list.

As a note, if someone needs to be added to multiple categories, please create multiple person objects.
