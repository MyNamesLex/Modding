local SetUpUI = {
    description  = "Setup UI"
}

function SetUpUI.setupNativeUI(LookAtEffects)
    local nativeSettings = GetMod("nativeSettings")

    -- Copy-pasted function, checks if CET is installed
    if not nativeSettings then
        print("[Better Scopes] Error: NativeSettings lib not found!")
        LookAtEffects.runtimeData.nativeSettingsInstalled = false
        return
    end

    -- Copy-pasted function, checks the CET version
    local cetVer = tonumber((GetVersion():gsub('^v(%d+)%.(%d+)%.(%d+)(.*)', function(major, minor, patch, wip) -- <-- This has been made by psiberx, all credits to him
        return ('%d.%02d%02d%d'):format(major, minor, patch, (wip == '' and 0 or 1))
    end)))
    -- Copy-pasted function, checks the CET version
    if cetVer < 1.18 then
        print("[Better Scopes] Error: CET version below required. The UI won't work because of this!")
        LookAtEffects.runtimeData.nativeSettingsInstalled = false
        return
    end
end