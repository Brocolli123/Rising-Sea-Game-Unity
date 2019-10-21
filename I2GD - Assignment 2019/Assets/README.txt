Changes:	------------------------------

Minor:
Figure out post processing on camera
Make underwater effects
Nicer UI elements
Tweak enemy spawning numbers
Falling platforms
frost number randomly changing in editor for some reason	(the depth?)
How to spawn the ragdoll of the specific enemy
Fade scenes for sounds
Gameover screen sounds
Health bar
Dead Theme?
Calling get score text every frame
Fish move and attack
invisiboy switch invisibility?
reimport ice cubes
import needed standardasset particlesystems
Check fog is working on uni computers
Scoremanager getting the text happening every frame causing error buildup

Major:
missing texture for smoke suit man particles and gunfire and player death		(reimport from basic pack??)


SAVE LOAD HIGHSCORES	-	USE SCORE MANAGER DISPLAY TOP 10 VALUES OF LIST
						-	ONLY HAVE 10 MAX LIST OF LENGTH (IF OVER DELETE LOWER
						-	VALUES) NEED TO ENTER PLAYER NAME ALONG WITH THE 
						-	SCORE IN THE HIGHSCORES. HAVE NAME STORED IN SAVEDATA?
						-	CHECK SAVEDATA, SCOREMANAGER, GAMEMANAGER
						-	Use string on gamemanager to add to list of strings on savedata
						-	save score based on name? (in gamemanager), add the two lists together
						-	to make 2d list and sort to top ten, then if player has one of top 10
						-	scores read file and ask player for name with INPUT FIELD and attatch it to their 
						-	score before saving it

						PLAYER HAS TO ENTER THEIR NAME BEFORE EXITING GAME END SCENE

						CHANGE SCENE THEN CHANGE STATE???

						https://docs.unity3d.com/ScriptReference/UI.InputField.html

						struct YourType {
    someint,
    somestring
}

List<YourType> // sort this by the int

OrderBy(x=> x.someint)
(yourlist.orderby)

LEADERBOARD CUNT SCRIPT
---------------------------------------------

Game Ideas:
Polar Ice/ Rising Sea Coast's level design
Wind Turbines to push enemies (buyable with points?)
Direct solar panels at enemies burns them
bullets slower underwater?
Harpoon gun?
Blood splatter decals??
Swimsuit + swimming option???? (temporary)
ice cubes on surface of water with collision to block player?	Enemies go through or not?
Gun weaker underwater?? use health instead of oneshot
Killing enemies lowers sea level?	(if water is negative)