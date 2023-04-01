function Merge(t1, t2) for k, v in pairs(t2) do t1[k] = v end end

Merge(Weapon,
{
	death_ray = L"Death Ray",
	death_rayTip2 = L"Use: Burns Through Anything",
})
