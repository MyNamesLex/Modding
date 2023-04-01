RegisterApplyMod(function()
	for k,v in ipairs(Materials) do
		v.BuildTime = 0
		v.ScrapTime = 0
	end

	portal = FindMaterial("portal")
	if portal and portal.WarmUpTime > 1 then
		portal.WarmUpTime = 0
	end
end)
