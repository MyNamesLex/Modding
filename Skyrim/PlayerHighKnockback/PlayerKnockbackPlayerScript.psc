Scriptname PlayerKnockbackPlayerScript extends ReferenceAlias

Event OnHit(ObjectReference akAggressor, Form akSource, Projectile akProjectile, bool abPowerAttack, bool abSneakAttack, \
    bool abBashAttack, bool abHitBlocked)
    akAggressor.PushActorAway(Game.GetPlayer(), 30)
    ;Debug.MessageBox("Hit!!!")
  EndEvent 