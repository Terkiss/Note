select chrid, type, damage, duration, attackFx,~~




select chrID, skillNumID from character_skill_info ;




select a.skillNumID, a.skillType, a.attackProperty, a.damage, a.subDamage, a.skillRunDuration, a.soundFx, a.attackFXSlot1 from skills a inner join skilldetailinfotbl b on a.skillNumID = b.skillNumID ;



// 스킬 조회 조인 sql문
SELECT chrINfo.chrID, chrINfo.skillNumID, detail.name, detail.description, s.skillType, s.attackProperty, s.damage, s.subDamage, 
s.skillRunDuration, s.soundFX, s.attackFXSlot1, s.attackFXSlot2, s.attackFXSlot3, s.attackFXSlot4 FROM character_skill_info chrINfo 
INNER JOIN skilldetailinfotbl detail ON chrINfo.skillNumID = detail.skillNumID INNER JOIN skills s ON detail.skillNumID = s.skillNumID;