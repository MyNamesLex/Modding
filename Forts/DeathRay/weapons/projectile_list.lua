table.insert(Projectiles,
{
    SaveName = "DeathRayBeam",
    ProjectileType = "beam",
	ProjectileSprite = "weapons/media/beam",
	ProjectileSpriteMipMap = true,
	DrawBlurredProjectile = false,
	ProjectileMass = 1.0,
	ProjectileDrag = 0.0,
	ProjectileIncendiary = true,
	IgnitesBackgroundMaterials = true,
	IgnitesBackgroundMaterialsPassing = true,
	IgnitesBackgroundMaterialsPassingSource = false,
	DeflectedByShields = false,
	DeflectedByTerrain = false,
	ExplodeOnTouch = false,
	Impact = 99999999,
	BeamScrollRate = -10,
	BeamOcclusionDistance = 1200,
	ProjectileDamage = 9999999.00,
	ImpactSize = 9999,
	SpeedIndicatorFactor = 0.05,
	ProjectileThickness = 30,
	BeamOcclusionDistanceWater = 1000,

	Effects =
	{
		Impact =
		{
			["foundations"] = "effects/beam_hit_ground.lua",
			["rocks01"] = "effects/beam_hit_ground.lua",
			["shield"] = "effects/energy_absorb.lua",
			["antiair"] = "effects/beam_antiair.lua",
			["default"] = "effects/beam_hit.lua",
		},
		Deflect =
		{
			["armour"] = "effects/beam_hit.lua",
			["door"] = "effects/beam_hit.lua",
			["shield"] = "effects/beam_hit.lua",
		},
	},

	DamageMultiplier =
	{
		{ SaveName = "machinegun", AntiAir = 0 },
		{ SaveName = "minigun", AntiAir = 0 },
		{ SaveName = "sniper", AntiAir = 0 },
		{ SaveName = "sniper2", AntiAir = 0 },
		{ SaveName = "cannon", AntiAir = 0 },
	},

	}
)