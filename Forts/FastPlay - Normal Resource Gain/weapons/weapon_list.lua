
RegisterApplyMod(function()
	if fastplay_ApplyMod then fastplay_ApplyMod() end

	local BuildDur = 0

	for k, device in ipairs(Weapons) do
		if device.BuildTimeComplete > BuildDur then
			device.BuildTimeComplete = BuildDur
		end
		if device.ScrapPeriod > BuildDur then
			device.ScrapPeriod = BuildDur
		end

		if device.Upgrades then
			for i, upgradeParams in pairs(device.Upgrades) do
				if upgradeParams.BuildDuration and upgradeParams.BuildDuration > BuildDur then
					upgradeParams.BuildDuration = BuildDur
				end
			end
		end
	end
end)