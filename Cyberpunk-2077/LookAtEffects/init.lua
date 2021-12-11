LookAtEffects = {
    Setup = {},
    Effects = {},
    description = "Causes effects when looking at NPC's",
    runtimeData = {
        cetOpen = false,
        nativeSettingsInstalled = true
     },
}

function LookAtEffects:new()
    registerForEvent("onInit", function()
        print("[LookAtEffects][INFO] Look At Effects Started!")
        LookAtEffects.Setup = require("SetupFolder/SetUpUI")
        -- Load Setup
        LookAtEffects.Setup.setupNativeUI()
        LookAtEffects.Effects = require("EffectsFolder/EffectsTracker")
    end)

    -- Keybinds for CET
    registerHotkey("AndroidTurnOff", "AndroidTurnOff KeyBind", function()
        if LookAtEffects.Effects.AndroidTurnOff == true then
            LookAtEffects.Effects.AndroidTurnOff = false
            print("[LookAtEffects][INFO] AndroidTurnOff Off")
        else
            LookAtEffects.Effects.AndroidTurnOff = true
            print("[LookAtEffects][INFO] AndroidTurnOff On")
        end
    end)
    registerHotkey("BeserkNPCBuff", "BeserkNPCBuff KeyBind", function()
        if LookAtEffects.Effects.BeserkNPCBuff == true then
            LookAtEffects.Effects.BeserkNPCBuff = false
            print("[LookAtEffects][INFO] BeserkNPCBuff Off")
        else
            LookAtEffects.Effects.BeserkNPCBuff = true
            print("[LookAtEffects][INFO] BeserkNPCBuff On")
        end
    end)
    registerHotkey("Burning", "Burning KeyBind", function()
        if LookAtEffects.Effects.Burning == true then
            LookAtEffects.Effects.Burning = false
            print("[LookAtEffects][INFO] Burning Off")
        else
            LookAtEffects.Effects.Burning = true
            print("[LookAtEffects][INFO] Burning On")
        end
    end)
    registerHotkey("Bleeding", "Bleeding KeyBind", function()
        if LookAtEffects.Effects.Bleeding == true then
            LookAtEffects.Effects.Bleeding = false
            print("[LookAtEffects][INFO] Bleeding Off")
        else
            LookAtEffects.Effects.Bleeding = true
            print("[LookAtEffects][INFO] Bleeding On")
        end
    end)
    registerHotkey("Blind", "Blind KeyBind", function()
        if LookAtEffects.Effects.Blind == true then
            LookAtEffects.Effects.Blind = false
            print("[LookAtEffects][INFO] Blind Off")
        else
            LookAtEffects.Effects.Blind = true
            print("[LookAtEffects][INFO] Blind On")
        end
    end)
    registerHotkey("CyberwareMalfunction", "CyberwareMalfunction KeyBind", function()
        if LookAtEffects.Effects.CyberWareMalfunction == true then
            LookAtEffects.Effects.CyberWareMalfunction = false
            print("[LookAtEffects][INFO] CyberWareMalfunction Off")
        else
            LookAtEffects.Effects.CyberWareMalfunction = true
            print("[LookAtEffects][INFO] CyberWareMalfunction On")
        end
    end)
    registerHotkey("Defeat", "Defeat KeyBind", function()
        if LookAtEffects.Effects.Defeat == true then
            LookAtEffects.Effects.Defeat = false
            print("[LookAtEffects][INFO] Defeat Off")
        else
            LookAtEffects.Effects.Defeat = true
            print("[LookAtEffects][INFO] Defeat On")
        end
    end)
    registerHotkey("Drugged", "Drugged KeyBind", function()
        if LookAtEffects.Effects.Drugged == true then
            LookAtEffects.Effects.Drugged = false
            print("[LookAtEffects][INFO] Drugged Off")
        else
            LookAtEffects.Effects.Drugged = true
            print("[LookAtEffects][INFO] Drugged On")
        end
    end)
    registerHotkey("Electrocuted", "Electrocuted KeyBind", function()
        if LookAtEffects.Effects.Electrocuted == true then
            LookAtEffects.Effects.Electrocuted = false
            print("[LookAtEffects][INFO] Electrocuted Off")
        else
            LookAtEffects.Effects.Electrocuted = true
            print("[LookAtEffects][INFO] Electrocuted On")
        end
    end)
    registerHotkey("ForceKill", "ForceKill KeyBind", function()
        if LookAtEffects.Effects.ForceKill == true then
            LookAtEffects.Effects.ForceKill = false
            print("[LookAtEffects][INFO] ForceKill Off")
        else
            LookAtEffects.Effects.ForceKill = true
            print("[LookAtEffects][INFO] ForceKill On")
        end
    end)
    registerHotkey("Grappled", "Grappled KeyBind", function()
        if LookAtEffects.Effects.Grappled == true then
            LookAtEffects.Effects.Grappled = false
            print("[LookAtEffects][INFO] Grappled Off")
        else
            LookAtEffects.Effects.Grappled = true
            print("[LookAtEffects][INFO] Grappled On")
        end
    end)
    registerHotkey("MemoryWipe", "MemoryWipe KeyBind", function()
        if LookAtEffects.Effects.MemoryWipe == true then
            LookAtEffects.Effects.MemoryWipe = false
            print("[LookAtEffects][INFO] MemoryWipe Off")
        else
            LookAtEffects.Effects.MemoryWipe = true
            print("[LookAtEffects][INFO] MemoryWipe On")
        end
    end)
    registerHotkey("Overload", "Overload KeyBind", function()
        if LookAtEffects.Effects.Overload == true then
            LookAtEffects.Effects.Overload = false
            print("[LookAtEffects][INFO] Overload Off")
        else
            LookAtEffects.Effects.Overload = true
            print("[LookAtEffects][INFO] Overload On")
        end
    end)
    registerHotkey("Stun", "Stun KeyBind", function()
        if LookAtEffects.Effects.Stun == true then
            LookAtEffects.Effects.Stun = false
            print("[LookAtEffects][INFO] Stun Off")
        else
            LookAtEffects.Effects.Stun = true
            print("[LookAtEffects][INFO] Stun On")
        end
    end)

    --unrelated but useful

    registerHotkey("PoliceChase", "Police Don't Chase KeyBind", function()
        if LookAtEffects.Effects.PoliceDontChase == true then
            LookAtEffects.Effects.PoliceDontChase = false
            Game.PrevSys_off()
            print("[LookAtEffects][INFO] Police Will Not Chase")
        else
            LookAtEffects.Effects.PoliceDontChase = true
            Game.PrevSys_on()
            print("[LookAtEffects][INFO] Police Will Chase")
        end
    end)

    registerForEvent("onShutdown", function()
        
    end)

    registerForEvent("onUpdate", function(delta)
        if LookAtEffects.Effects.AndroidTurnOff == true then
            Game.ApplyEffectOnNPC("BaseStatusEffect.AndroidTurnOff")
        end
        if LookAtEffects.Effects.BeserkNPCBuff == true then
            Game.ApplyEffectOnNPC("BaseStatusEffect.BeserkNPCBuff")
        end
        if LookAtEffects.Effects.Burning == true then
            Game.ApplyEffectOnNPC("BaseStatusEffect.Burning")
        end
        if LookAtEffects.Effects.Bleeding == true then
            Game.ApplyEffectOnNPC("BaseStatusEffect.Bleeding")
        end
        if LookAtEffects.Effects.Blind == true then
            Game.ApplyEffectOnNPC("BaseStatusEffect.Blind")
        end
        if LookAtEffects.Effects.CyberWareMalfunction == true then
            Game.ApplyEffectOnNPC("BaseStatusEffect.CyberwareMalfunction")
        end
        if LookAtEffects.Effects.Defeat == true then
            Game.ApplyEffectOnNPC("BaseStatusEffect.Defeat")
        end
        if LookAtEffects.Effects.Drugged == true then
            Game.ApplyEffectOnNPC("BaseStatusEffect.Drugged")
        end
        if LookAtEffects.Effects.Electrocuted == true then
            Game.ApplyEffectOnNPC("BaseStatusEffect.Electrocuted")
        end
        if LookAtEffects.Effects.ForceKill == true then
            Game.ApplyEffectOnNPC("BaseStatusEffect.ForceKill")
        end
        if LookAtEffects.Effects.Grappled == true then
            Game.ApplyEffectOnNPC("BaseStatusEffect.Grappled")
        end
        if LookAtEffects.Effects.MemoryWipe == true then
            Game.ApplyEffectOnNPC("BaseStatusEffect.MemoryWipe")
        end
        if LookAtEffects.Effects.Overload == true then
            Game.ApplyEffectOnNPC("BaseStatusEffect.Overload")
        end
        if LookAtEffects.Effects.Stun == true then
            Game.ApplyEffectOnNPC("BaseStatusEffect.Stun")
        end
    end)

end

return LookAtEffects:new()