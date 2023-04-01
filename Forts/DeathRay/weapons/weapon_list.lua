table.insert(Sprites, DetailSprite("hud-detail-battery-large", "HUD-Details-Battery", path))
table.insert(Sprites, ButtonSprite("hud-battery-icon", "HUD/HUD-Battery", nil, ButtonSpriteBottom, nil, nil, path))

table.insert(Weapons, IndexOfWeapon("deathray") + 1,
{
	SaveName = "death_ray",
	FileName = path .. "/weapons/death_ray.lua",
	Icon = "hud-battery-icon",
	Detail = "hud-detail-battery-large",
    GroupButton = "hud-group-machinegun",
    BuildTimeComplete = 2.0,
    ScrapPeriod = 5,
    MetalCost = 1500,
    EnergyCost = 7000,
	MetalRepairCost = 7.5,
	EnergyRepairCost = 225,
	MaxSpotterAssistance = 0,
	MaxUpAngle = StandardMaxUpAngle,
	Prerequisite = "factory",
	BuildOnGroundOnly = false,
	FireGroupWhenDoorBlocks = true,
	SelectEffect = "ui/hud/weapons/ui_weapons",
})