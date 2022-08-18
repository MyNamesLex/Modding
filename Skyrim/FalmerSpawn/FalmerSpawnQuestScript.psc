Scriptname FalmerSpawnQuestScript extends ReferenceAlias  

Event OnInit()
    RegisterForUpdate(5.0)
EndEvent
Event OnUpdate()
    ObjectReference Falmer = Game.GetPlayer().PlaceAtMe(Game.GetForm(0x00023a99))
EndEvent