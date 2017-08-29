Public Class OWAPI
    Public Class OWAPIResponse
        Public Property eu As Us
        Public Property any As Us
        Public Property us As Us
        Public Property _request As _Request
        Public Property kr As Us
    End Class

    Public Class Us
        Public Property achievements As Achievements
        Public Property stats As Stats
        Public Property heroes As Heroes
    End Class

    Public Class Achievements
        Public Property tank As Tank
        Public Property support As Support
        Public Property maps As Maps
        Public Property special As Special
        Public Property defense As Defense
        Public Property general As General
        Public Property offense As Offense
    End Class

    Public Class Tank
        Public Property shot_down As Boolean
        Public Property halt_state As Boolean
        Public Property hog_wild As Boolean
        Public Property i_am_your_shield As Boolean
        Public Property mine_sweeper As Boolean
        Public Property power_overwhelming As Boolean
        Public Property giving_you_the_hook As Boolean
        Public Property game_over As Boolean
        Public Property the_power_of_attraction As Boolean
        Public Property anger_management As Boolean
        Public Property overclocked As Boolean
        Public Property storm_earth_and_fire As Boolean
    End Class

    Public Class Support
        Public Property enabler As Boolean
        Public Property supersonic As Boolean
        Public Property the_floor_is_lava As Boolean
        Public Property huge_rez As Boolean
        Public Property the_iris_embraces_you As Boolean
        Public Property rapid_discord As Boolean
        Public Property the_car_wash As Boolean
        Public Property huge_success As Boolean
        Public Property group_health_plan As Boolean
        Public Property naptime As Boolean
    End Class

    Public Class Maps
        Public Property escort_duty As Boolean
        Public Property shutout As Boolean
        Public Property world_traveler As Boolean
        Public Property lockdown As Boolean
        Public Property cant_touch_this As Boolean
        Public Property double_cap As Boolean
    End Class

    Public Class Special
        Public Property cleanup_duty As Boolean
        Public Property survived_the_night As Boolean
        Public Property snowed_in As Boolean
        Public Property ambush As Boolean
        Public Property held_the_door As Boolean
        Public Property whap As Boolean
        Public Property cool_as_ice As Boolean
        Public Property flagbearer As Boolean
        Public Property not_a_scratch As Boolean
        Public Property four_they_were As Boolean
    End Class

    Public Class Defense
        Public Property did_that_sting As Boolean
        Public Property armor_up As Boolean
        Public Property ice_blocked As Boolean
        Public Property cold_snap As Boolean
        Public Property mine_like_a_steel_trap As Boolean
        Public Property roadkill As Boolean
        Public Property simple_geometry As Boolean
        Public Property raid_wipe As Boolean
        Public Property charge As Boolean
        Public Property the_dragon_is_sated As Boolean
        Public Property smooth_as_silk As Boolean
        Public Property triple_threat As Boolean
    End Class

    Public Class General
        Public Property level_25 As Boolean
        Public Property decorated As Boolean
        Public Property the_path_is_closed As Boolean
        Public Property level_50 As Boolean
        Public Property survival_expert As Boolean
        Public Property blackjack As Boolean
        Public Property centenary As Boolean
        Public Property undying As Boolean
        Public Property level_10 As Boolean
        Public Property the_friend_zone As Boolean
        Public Property decked_out As Boolean
    End Class

    Public Class Offense
        Public Property whoa_there As Boolean
        Public Property special_delivery As Boolean
        Public Property rocket_man As Boolean
        Public Property their_own_worst_enemy As Boolean
        Public Property clearing_the_area As Boolean
        Public Property waste_not_want_not As Boolean
        Public Property power_outage As Boolean
        Public Property total_recall As Boolean
        Public Property hack_the_planet As Boolean
        Public Property death_from_above As Boolean
        Public Property die_die_die_die As Boolean
        Public Property target_rich_environment As Boolean
        Public Property slice_and_dice As Boolean
        Public Property its_high_noon As Boolean
    End Class

    Public Class Stats
        Public Property competitive As Competitive
        Public Property quickplay As Quickplay
    End Class

    Public Class Competitive
        Public Property average_stats As Average_Stats
        Public Property competitive As Boolean
        Public Property overall_stats As Overall_Stats
        Public Property game_stats As Game_Stats
    End Class

    Public Class Average_Stats
        Public Property objective_kills_avg As Single
        Public Property deaths_avg As Single
        Public Property healing_done_avg As Single
        Public Property objective_time_avg As Single
        Public Property time_spent_on_fire_avg As Single
        Public Property final_blows_avg As Single
        Public Property solo_kills_avg As Single
        Public Property damage_done_avg As Single
        Public Property melee_final_blows_avg As Single
        Public Property eliminations_avg As Single
    End Class

    Public Class Overall_Stats
        Public Property comprank As Integer
        Public Property ties As Integer
        Public Property avatar As String
        Public Property wins As Integer
        Public Property rank_image As String
        Public Property tier As String
        Public Property win_rate As Single
        Public Property prestige As Integer
        Public Property level As Integer
        Public Property losses As Integer
        Public Property games As Integer
    End Class

    Public Class Game_Stats
        Public Property kpd As Single
        Public Property kill_streak_best As Single
        Public Property eliminations_most_in_game As Single
        Public Property solo_kills_most_in_game As Single
        Public Property offensive_assists As Single
        Public Property medals As Single
        Public Property objective_kills As Single
        Public Property objective_time As Single
        Public Property offensive_assists_most_in_game As Single
        Public Property final_blows_most_in_game As Single
        Public Property environmental_kills As Single
        Public Property objective_time_most_in_game As Single
        Public Property final_blows As Single
        Public Property environmental_deaths As Single
        Public Property environmental_kill_most_in_game As Single
        Public Property melee_final_blows_most_in_game As Single
        Public Property time_spent_on_fire As Single
        Public Property games_lost As Single
        Public Property melee_final_blows As Single
        Public Property medals_gold As Single
        Public Property healing_done_most_in_game As Single
        Public Property medals_bronze As Single
        Public Property damage_done As Single
        Public Property objective_kills_most_in_game As Single
        Public Property cards As Single
        Public Property turret_destroyed As Single
        Public Property solo_kills As Single
        Public Property eliminations As Single
        Public Property time_spent_on_fire_most_in_game As Single
        Public Property medals_silver As Single
        Public Property healing_done As Single
        Public Property games_won As Single
        Public Property defensive_assists As Single
        Public Property defensive_assists_most_in_game As Single
        Public Property damage_done_most_in_game As Single
        Public Property turret_destroyed_most_in_game As Single
        Public Property games_played As Single
        Public Property deaths As Single
        Public Property time_played As Single
    End Class

    Public Class Quickplay
        Public Property average_stats As Average_Stats1
        Public Property competitive As Boolean
        Public Property overall_stats As Overall_Stats1
        Public Property game_stats As Game_Stats1
    End Class

    Public Class Average_Stats1
        Public Property objective_kills_avg As Single
        Public Property deaths_avg As Single
        Public Property healing_done_avg As Single
        Public Property objective_time_avg As Single
        Public Property time_spent_on_fire_avg As Single
        Public Property final_blows_avg As Single
        Public Property solo_kills_avg As Single
        Public Property damage_done_avg As Single
        Public Property melee_final_blows_avg As Single
        Public Property eliminations_avg As Single
    End Class

    Public Class Overall_Stats1
        Public Property comprank As Integer
        Public Property avatar As String
        Public Property wins As Integer
        Public Property rank_image As String
        Public Property tier As String
        Public Property win_rate As Single
        Public Property prestige As Integer
        Public Property level As Integer
        Public Property losses As Integer
        Public Property games As Integer
    End Class

    Public Class Game_Stats1
        Public Property shield_generator_destroyed_most_in_game As Single
        Public Property eliminations_most_in_game As Single
        Public Property environmental_kills As Single
        Public Property recon_assists_most_in_game As Single
        Public Property objective_kills As Single
        Public Property objective_time As Single
        Public Property kill_streak_best As Single
        Public Property objective_time_most_in_game As Single
        Public Property turrets_destroyed As Single
        Public Property final_blows As Single
        Public Property offensive_assists As Single
        Public Property defensive_assists As Single
        Public Property defensive_assists_most_in_game As Single
        Public Property environmental_deaths As Single
        Public Property medals_gold As Single
        Public Property recon_assists As Single
        Public Property games_won As Single
        Public Property medals_silver As Single
        Public Property eliminations As Single
        Public Property turrets_destroyed_most_in_game As Single
        Public Property teleporter_pads_destroyed As Single
        Public Property kpd As Single
        Public Property multikills As Single
        Public Property teleporter_pad_destroyed_most_in_game As Single
        Public Property solo_kills_most_in_game As Single
        Public Property offensive_assists_most_in_game As Single
        Public Property final_blows_most_in_game As Single
        Public Property medals As Single
        Public Property time_spent_on_fire As Single
        Public Property solo_kills As Single
        Public Property melee_final_blows_most_in_game As Single
        Public Property melee_final_blows As Single
        Public Property environmental_kills_most_in_game As Single
        Public Property multikill_best As Single
        Public Property damage_done As Single
        Public Property objective_kills_most_in_game As Single
        Public Property cards As Single
        Public Property healing_done_most_in_game As Single
        Public Property time_spent_on_fire_most_in_game As Single
        Public Property healing_done As Single
        Public Property medals_bronze As Single
        Public Property shield_generators_destroyed As Single
        Public Property damage_done_most_in_game As Single
        Public Property deaths As Single
        Public Property time_played As Single
    End Class

    Public Class Heroes
        Public Property stats As Stats1
        Public Property playtime As Playtime
    End Class

    Public Class Stats1
        Public Property competitive As Competitive1
        Public Property quickplay As Quickplay1
    End Class

    Public Class Competitive1
        Public Property zarya As Zarya
        Public Property roadhog As Roadhog
        Public Property reinhardt As Reinhardt
        Public Property ana As Ana
        Public Property winston As Winston
        Public Property lucio As Lucio
        Public Property junkrat As Junkrat
        Public Property pharah As Pharah
        Public Property soldier76 As Soldier76
    End Class

    Public Class Zarya
        Public Property average_stats As Average_Stats2
        Public Property hero_stats As Hero_Stats
        Public Property general_stats As General_Stats
    End Class

    Public Class Average_Stats2
        Public Property lifetime_average_energy As Single
        Public Property damage_blocked_average As Single
        Public Property eliminations_average As Single
        Public Property high_energy_kills_average As Single
        Public Property projected_barriers_applied_average As Single
        Public Property objective_time_average As Single
        Public Property objective_kills_average As Single
        Public Property average_energy_best_in_game As Single
        Public Property deaths_average As Single
        Public Property damage_done_average As Single
    End Class

    Public Class Hero_Stats
        Public Property high_energy_kill_most_in_game As Single
        Public Property high_energy_kill As Single
        Public Property lifetime_energy_accumulation As Single
        Public Property projected_barriers_applied As Single
        Public Property damage_blocked As Single
        Public Property damage_blocked_most_in_game As Single
        Public Property energy_maximum As Single
    End Class

    Public Class General_Stats
        Public Property weapon_accuracy As Single
        Public Property eliminations As Single
        Public Property shots_fired As Single
        Public Property objective_kills As Single
        Public Property objective_time As Single
        Public Property time_played As Single
        Public Property kill_streak_best As Single
        Public Property medals As Single
        Public Property objective_time_most_in_game As Single
        Public Property projected_barriers_applied_most_in_game As Single
        Public Property shots_hit As Single
        Public Property win_percentage As Single
        Public Property games_lost As Single
        Public Property eliminations_most_in_life As Single
        Public Property damage_done_most_in_life As Single
        Public Property damage_done As Single
        Public Property objective_kills_most_in_game As Single
        Public Property death As Single
        Public Property medals_gold As Single
        Public Property games_won As Single
        Public Property eliminations_per_life As Single
        Public Property medals_silver As Single
        Public Property damage_done_most_in_game As Single
        Public Property eliminations_most_in_game As Single
        Public Property games_played As Single
    End Class

    Public Class Roadhog
        Public Property average_stats As Average_Stats3
        Public Property hero_stats As Hero_Stats1
        Public Property general_stats As General_Stats1
    End Class

    Public Class Average_Stats3
        Public Property self_healing_average As Single
        Public Property critical_hits_average As Single
        Public Property enemies_hooked_average As Single
        Public Property eliminations_average As Single
        Public Property damage_done_average As Single
        Public Property objective_kills_average As Single
        Public Property objective_time_average As Single
        Public Property deaths_average As Single
        Public Property final_blows_average As Single
        Public Property healing_done_average As Single
    End Class

    Public Class Hero_Stats1
        Public Property enemies_hooked_most_in_game As Single
        Public Property enemies_hooked As Single
        Public Property hooks_attempted As Single
        Public Property hook_accuracy As Single
        Public Property hook_accuracy_best_in_game As Single
    End Class

    Public Class General_Stats1
        Public Property final_blow As Single
        Public Property weapon_accuracy As Single
        Public Property eliminations As Single
        Public Property self_healing As Single
        Public Property medals As Single
        Public Property objective_kills As Single
        Public Property objective_time As Single
        Public Property time_played As Single
        Public Property kill_streak_best As Single
        Public Property shots_fired As Single
        Public Property objective_time_most_in_game As Single
        Public Property deaths As Single
        Public Property final_blow_most_in_game As Single
        Public Property healing_done_most_in_life As Single
        Public Property self_healing_most_in_game As Single
        Public Property shots_hit As Single
        Public Property win_percentage As Single
        Public Property games_lost As Single
        Public Property elimination_per_life As Single
        Public Property healing_done_most_in_game As Single
        Public Property eliminations_most_in_life As Single
        Public Property damage_done_most_in_life As Single
        Public Property damage_done As Single
        Public Property objective_kills_most_in_game As Single
        Public Property games_played As Single
        Public Property medals_gold As Single
        Public Property games_won As Single
        Public Property critical_hits As Single
        Public Property critical_hits_most_in_game As Single
        Public Property medals_bronze As Single
        Public Property critical_hit_accuracy As Single
        Public Property medals_silver As Single
        Public Property damage_done_most_in_game As Single
        Public Property eliminations_most_in_game As Single
        Public Property critical_hits_most_in_life As Single
        Public Property healing_done As Single
    End Class

    Public Class Reinhardt
        Public Property average_stats As Average_Stats4
        Public Property hero_stats As Hero_Stats2
        Public Property general_stats As General_Stats2
    End Class

    Public Class Average_Stats4
        Public Property earthshatter_kills_average As Single
        Public Property damage_done_average As Single
        Public Property objective_kills_average As Single
        Public Property objective_time_average As Single
        Public Property solo_kills_average As Single
        Public Property fire_strike_kills_average As Single
        Public Property charge_kills_average As Single
        Public Property damage_blocked_average As Single
        Public Property offensive_assists_average As Single
        Public Property eliminations_average As Single
        Public Property deaths_average As Single
        Public Property final_blows_average As Single
        Public Property time_spent_on_fire_average As Single
    End Class

    Public Class Hero_Stats2
        Public Property fire_strike_kills_most_in_game As Single
        Public Property earthshatter_kills As Single
        Public Property damage_blocked_most_in_game As Single
        Public Property fire_strike_kills As Single
        Public Property charge_kills_most_in_game As Single
        Public Property damage_blocked As Single
        Public Property earthshatter_kills_most_in_game As Single
        Public Property charge_kills As Single
    End Class

    Public Class General_Stats2
        Public Property kill_streak_best As Single
        Public Property solo_kill As Single
        Public Property eliminations As Single
        Public Property medals As Single
        Public Property objective_kills As Single
        Public Property objective_time As Single
        Public Property offensive_assists_most_in_game As Single
        Public Property final_blows_most_in_game As Single
        Public Property solo_kill_most_in_game As Single
        Public Property objective_time_most_in_game As Single
        Public Property final_blows As Single
        Public Property environmental_deaths As Single
        Public Property offensive_assists As Single
        Public Property games_lost As Single
        Public Property time_spent_on_fire As Single
        Public Property eliminations_most_in_life As Single
        Public Property damage_done_most_in_life As Single
        Public Property damage_done As Single
        Public Property objective_kills_most_in_game As Single
        Public Property cards As Single
        Public Property turret_destroyed As Single
        Public Property win_percentage As Single
        Public Property medals_gold As Single
        Public Property time_spent_on_fire_most_in_game As Single
        Public Property games_won As Single
        Public Property medals_bronze As Single
        Public Property eliminations_per_life As Single
        Public Property medals_silver As Single
        Public Property damage_done_most_in_game As Single
        Public Property eliminations_most_in_game As Single
        Public Property games_played As Single
        Public Property deaths As Single
        Public Property time_played As Single
    End Class

    Public Class Ana
        Public Property average_stats As Average_Stats5
        Public Property hero_stats As Hero_Stats3
        Public Property general_stats As General_Stats3
    End Class

    Public Class Average_Stats5
        Public Property enemies_slept_average As Single
        Public Property defensive_assists_average As Single
        Public Property eliminations_average As Single
        Public Property nano_boost_assists_average As Single
        Public Property objective_kills_average As Single
        Public Property solo_kills_average As Single
        Public Property offensive_assists_average As Single
        Public Property healing_done_average As Single
        Public Property self_healing_average As Single
        Public Property melee_final_blows_average As Single
        Public Property nano_boosts_applied_average As Single
        Public Property damage_done_average As Single
        Public Property deaths_average As Single
        Public Property final_blows_average As Single
        Public Property time_spent_on_fire_average As Single
        Public Property objective_time_average As Single
    End Class

    Public Class Hero_Stats3
        Public Property melee_final_blows_most_in_game As Single
        Public Property unscoped_accuracy As Single
        Public Property scoped_hits As Single
        Public Property scoped_accuracy_best_in_game As Single
        Public Property nano_boost_assists_most_in_game As Single
        Public Property nano_boosts_applied As Single
        Public Property scoped_shots As Single
        Public Property nano_boost_assists As Single
        Public Property scoped_accuracy As Single
    End Class

    Public Class General_Stats3
        Public Property enemies_slept_most_in_game As Single
        Public Property eliminations_most_in_game As Single
        Public Property objective_kills As Single
        Public Property objective_time As Single
        Public Property kill_streak_best As Single
        Public Property shots_fired As Single
        Public Property objective_time_most_in_game As Single
        Public Property final_blows As Single
        Public Property unscoped_shots As Single
        Public Property weapon_accuracy_best_in_game As Single
        Public Property healing_done_most_in_life As Single
        Public Property shots_hit As Single
        Public Property offensive_assists As Single
        Public Property defensive_assists As Single
        Public Property games_lost As Single
        Public Property damage_done_most_in_life As Single
        Public Property environmental_deaths As Single
        Public Property solo_kills_most_in_game As Single
        Public Property games_won As Single
        Public Property nano_boosts_applied_most_in_game As Single
        Public Property eliminations_per_life As Single
        Public Property defensive_assists_most_in_game As Single
        Public Property unscoped_hits As Single
        Public Property weapon_accuracy As Single
        Public Property eliminations As Single
        Public Property self_healing As Single
        Public Property self_healing_most_in_game As Single
        Public Property offensive_assists_most_in_game As Single
        Public Property final_blows_most_in_game As Single
        Public Property medals As Single
        Public Property time_spent_on_fire As Single
        Public Property solo_kills As Single
        Public Property unscoped_accuracy_best_in_game As Single
        Public Property win_percentage As Single
        Public Property melee_final_blows As Single
        Public Property healing_done_most_in_game As Single
        Public Property eliminations_most_in_life As Single
        Public Property damage_done As Single
        Public Property objective_kills_most_in_game As Single
        Public Property time_spent_on_fire_most_in_game As Single
        Public Property medals_silver As Single
        Public Property healing_done As Single
        Public Property medals_bronze As Single
        Public Property enemies_slept As Single
        Public Property damage_done_most_in_game As Single
        Public Property games_played As Single
        Public Property deaths As Single
        Public Property time_played As Single
    End Class

    Public Class Winston
        Public Property average_stats As Average_Stats6
        Public Property hero_stats As Hero_Stats4
        Public Property general_stats As General_Stats4
    End Class

    Public Class Average_Stats6
        Public Property jump_pack_kills_average As Single
        Public Property eliminations_average As Single
        Public Property objective_kills_average As Single
        Public Property objective_time_average As Single
        Public Property damage_done_average As Single
        Public Property primal_rage_kills_average As Single
        Public Property damage_blocked_average As Single
        Public Property melee_kills_average As Single
        Public Property players_knocked_back_average As Single
        Public Property solo_kills_average As Single
        Public Property deaths_average As Single
        Public Property final_blows_average As Single
        Public Property time_spent_on_fire_average As Single
    End Class

    Public Class Hero_Stats4
        Public Property melee_kills As Single
        Public Property players_knocked_back As Single
        Public Property players_knocked_back_most_in_game As Single
        Public Property jump_pack_kills_most_in_game As Single
        Public Property damage_blocked As Single
        Public Property melee_kills_most_in_game As Single
        Public Property damage_blocked_most_in_game As Single
        Public Property jump_pack_kills As Single
    End Class

    Public Class General_Stats4
        Public Property primal_rage_kills As Single
        Public Property kill_streak_best As Single
        Public Property eliminations_most_in_game As Single
        Public Property eliminations As Single
        Public Property environmental_kills As Single
        Public Property objective_kills As Single
        Public Property objective_time As Single
        Public Property time_played As Single
        Public Property final_blows_most_in_game As Single
        Public Property solo_kill_most_in_game As Single
        Public Property objective_time_most_in_game As Single
        Public Property final_blows As Single
        Public Property environmental_deaths As Single
        Public Property time_spent_on_fire As Single
        Public Property games_lost As Single
        Public Property eliminations_most_in_life As Single
        Public Property damage_done_most_in_life As Single
        Public Property damage_done As Single
        Public Property objective_kills_most_in_game As Single
        Public Property time_spent_on_fire_most_in_game As Single
        Public Property solo_kills As Single
        Public Property win_percentage As Single
        Public Property medals_gold As Single
        Public Property medals As Single
        Public Property games_won As Single
        Public Property medals_bronze As Single
        Public Property eliminations_per_life As Single
        Public Property medals_silver As Single
        Public Property damage_done_most_in_game As Single
        Public Property primal_rage_kills_most_in_game As Single
        Public Property games_played As Single
        Public Property deaths As Single
    End Class

    Public Class Lucio
        Public Property average_stats As Average_Stats7
        Public Property hero_stats As Hero_Stats5
        Public Property general_stats As General_Stats5
    End Class

    Public Class Average_Stats7
        Public Property critical_hits_average As Single
        Public Property sound_barriers_provided_average As Single
        Public Property defensive_assists_average As Single
        Public Property objective_kills_average As Single
        Public Property objective_time_average As Single
        Public Property offensive_assists_average As Single
        Public Property self_healing_average As Single
        Public Property healing_done_average As Single
        Public Property damage_done_average As Single
        Public Property eliminations_average As Single
        Public Property deaths_average As Single
        Public Property final_blows_average As Single
    End Class

    Public Class Hero_Stats5
        Public Property sound_barriers_provided_most_in_game As Single
        Public Property sound_barriers_provided As Single
    End Class

    Public Class General_Stats5
        Public Property defensive_assists As Single
        Public Property final_blows_most_in_game As Single
        Public Property weapon_accuracy As Single
        Public Property eliminations As Single
        Public Property self_healing As Single
        Public Property medals As Single
        Public Property objective_kills As Single
        Public Property objective_time As Single
        Public Property time_played As Single
        Public Property kill_streak_best As Single
        Public Property shots_fired As Single
        Public Property objective_time_most_in_game As Single
        Public Property final_blows As Single
        Public Property deaths As Single
        Public Property defensive_assists_most_in_game As Single
        Public Property healing_done_most_in_life As Single
        Public Property self_healing_most_in_game As Single
        Public Property shots_hit As Single
        Public Property offensive_assists As Single
        Public Property elimination_per_life As Single
        Public Property healing_done_most_in_game As Single
        Public Property eliminations_most_in_life As Single
        Public Property damage_done_most_in_life As Single
        Public Property damage_done As Single
        Public Property objective_kills_most_in_game As Single
        Public Property critical_hit_accuracy As Single
        Public Property games_played As Single
        Public Property win_percentage As Single
        Public Property games_lost As Single
        Public Property games_won As Single
        Public Property critical_hits As Single
        Public Property offensive_assist_most_in_game As Single
        Public Property medals_bronze As Single
        Public Property weapon_accuracy_best_in_game As Single
        Public Property medals_silver As Single
        Public Property damage_done_most_in_game As Single
        Public Property eliminations_most_in_game As Single
        Public Property critical_hits_most_in_life As Single
        Public Property healing_done As Single
        Public Property critical_hits_most_in_game As Single
    End Class

    Public Class Junkrat
        Public Property average_stats As Average_Stats8
        Public Property hero_stats As Hero_Stats6
        Public Property general_stats As General_Stats6
    End Class

    Public Class Average_Stats8
        Public Property final_blows_average As Single
        Public Property eliminations_average As Single
        Public Property damage_done_average As Single
        Public Property objective_time_average As Single
        Public Property objective_kills_average As Single
        Public Property solo_kills_average As Single
        Public Property deaths_average As Single
        Public Property offensive_assists_average As Single
        Public Property time_spent_on_fire_average As Single
        Public Property rip_tire_kills_average As Single
    End Class

    Public Class Hero_Stats6
        Public Property enemies_trapped As Single
        Public Property rip_tire_kills_most_in_game As Single
        Public Property enemies_trapped_a_minute As Single
        Public Property rip_tire_kills As Single
        Public Property enemies_trapped_most_in_game As Single
    End Class

    Public Class General_Stats6
        Public Property kill_streak_best As Single
        Public Property weapon_accuracy As Single
        Public Property eliminations As Single
        Public Property medals As Single
        Public Property objective_kills As Single
        Public Property objective_time As Single
        Public Property offensive_assists_most_in_game As Single
        Public Property final_blows_most_in_game As Single
        Public Property shots_fired As Single
        Public Property objective_time_most_in_game As Single
        Public Property final_blows As Single
        Public Property solo_kills As Single
        Public Property shots_hit As Single
        Public Property offensive_assists As Single
        Public Property games_lost As Single
        Public Property time_spent_on_fire As Single
        Public Property eliminations_most_in_life As Single
        Public Property damage_done_most_in_life As Single
        Public Property damage_done As Single
        Public Property objective_kills_most_in_game As Single
        Public Property games_played As Single
        Public Property win_percentage As Single
        Public Property solo_kills_most_in_game As Single
        Public Property time_spent_on_fire_most_in_game As Single
        Public Property games_won As Single
        Public Property eliminations_per_life As Single
        Public Property medals_bronze As Single
        Public Property weapon_accuracy_best_in_game As Single
        Public Property medals_silver As Single
        Public Property damage_done_most_in_game As Single
        Public Property eliminations_most_in_game As Single
        Public Property environmental_death As Single
        Public Property deaths As Single
        Public Property time_played As Single
    End Class

    Public Class Pharah
        Public Property average_stats As Average_Stats9
        Public Property hero_stats As Hero_Stats7
        Public Property general_stats As General_Stats7
    End Class

    Public Class Average_Stats9
        Public Property rocket_direct_hits_average As Single
        Public Property final_blows_average As Single
        Public Property eliminations_average As Single
        Public Property damage_done_average As Single
        Public Property objective_time_average As Single
        Public Property objective_kills_average As Single
        Public Property solo_kills_average As Single
        Public Property deaths_average As Single
        Public Property barrage_kills_average As Single
    End Class

    Public Class Hero_Stats7
        Public Property rocket_direct_hits_most_in_game As Single
        Public Property rocket_direct_hits As Single
        Public Property barrage_kill_most_in_game As Single
        Public Property barrage_kill As Single
    End Class

    Public Class General_Stats7
        Public Property kill_streak_best As Single
        Public Property weapon_accuracy As Single
        Public Property eliminations As Single
        Public Property medals As Single
        Public Property objective_kills As Single
        Public Property objective_time As Single
        Public Property time_played As Single
        Public Property final_blows_most_in_game As Single
        Public Property shots_fired As Single
        Public Property objective_time_most_in_game As Single
        Public Property final_blows As Single
        Public Property solo_kills As Single
        Public Property shots_hit As Single
        Public Property win_percentage As Single
        Public Property games_lost As Single
        Public Property eliminations_most_in_life As Single
        Public Property damage_done_most_in_life As Single
        Public Property damage_done As Single
        Public Property objective_kills_most_in_game As Single
        Public Property solo_kills_most_in_game As Single
        Public Property games_won As Single
        Public Property medals_bronze As Single
        Public Property eliminations_per_life As Single
        Public Property medals_silver As Single
        Public Property damage_done_most_in_game As Single
        Public Property eliminations_most_in_game As Single
        Public Property games_played As Single
        Public Property deaths As Single
    End Class

    Public Class Soldier76
        Public Property average_stats As Average_Stats10
        Public Property hero_stats As Hero_Stats8
        Public Property general_stats As General_Stats8
    End Class

    Public Class Average_Stats10
        Public Property self_healing_average As Single
        Public Property critical_hits_average As Single
        Public Property healing_done_average As Single
        Public Property eliminations_average As Single
        Public Property damage_done_average As Single
        Public Property objective_kills_average As Single
        Public Property objective_time_average As Single
        Public Property deaths_average As Single
    End Class

    Public Class Hero_Stats8
        Public Property biotic_fields_deployed As Single
        Public Property biotic_field_healing_done As Single
    End Class

    Public Class General_Stats8
        Public Property elimination As Single
        Public Property weapon_accuracy As Single
        Public Property self_healing As Single
        Public Property shots_fired As Single
        Public Property self_healing_most_in_game As Single
        Public Property objective_time As Single
        Public Property critical_hits_most_in_life As Single
        Public Property time_played As Single
        Public Property kill_streak_best As Single
        Public Property elimination_most_in_game As Single
        Public Property objective_time_most_in_game As Single
        Public Property weapon_accuracy_best_in_game As Single
        Public Property healing_done_most_in_life As Single
        Public Property shots_hit As Single
        Public Property win_percentage As Single
        Public Property healing_done_most_in_game As Single
        Public Property deaths As Single
        Public Property damage_done_most_in_life As Single
        Public Property damage_done As Single
        Public Property games_played As Single
        Public Property elimination_most_in_life As Single
        Public Property medals_gold As Single
        Public Property medals As Single
        Public Property games_won As Single
        Public Property critical_hit_accuracy As Single
        Public Property critical_hits_most_in_game As Single
        Public Property eliminations_per_life As Single
        Public Property medals_bronze As Single
        Public Property critical_hits As Single
        Public Property damage_done_most_in_game As Single
        Public Property games_lost As Single
        Public Property objective_kill As Single
        Public Property healing_done As Single
        Public Property objective_kill_most_in_game As Single
    End Class

    Public Class Quickplay1
        Public Property widowmaker As Widowmaker
        Public Property ana As Ana1
        Public Property winston As Winston1
        Public Property mei As Mei
        Public Property tracer As Tracer
        Public Property orisa As Orisa
        Public Property symmetra As Symmetra
        Public Property hanzo As Hanzo
        Public Property lucio As Lucio1
        Public Property mercy As Mercy
        Public Property sombra As Sombra
        Public Property mccree As Mccree
        Public Property reaper As Reaper
        Public Property genji As Genji
        Public Property zenyatta As Zenyatta
        Public Property bastion As Bastion
        Public Property zarya As Zarya1
        Public Property roadhog As Roadhog1
        Public Property reinhardt As Reinhardt1
        Public Property soldier76 As Soldier761
        Public Property dva As Dva
        Public Property junkrat As Junkrat1
        Public Property pharah As Pharah1
        Public Property torbjorn As Torbjorn
    End Class

    Public Class Widowmaker
        Public Property average_stats As Average_Stats11
        Public Property hero_stats As Hero_Stats9
        Public Property general_stats As General_Stats9
    End Class

    Public Class Average_Stats11
        Public Property critical_hits_average As Single
        Public Property eliminations_average As Single
        Public Property scoped_critical_hits_average As Single
        Public Property objective_kills_average As Single
        Public Property objective_time_average As Single
        Public Property damage_done_average As Single
        Public Property melee_final_blows_average As Single
        Public Property venom_mine_kills_average As Single
        Public Property solo_kills_average As Single
        Public Property deaths_average As Single
        Public Property final_blows_average As Single
        Public Property time_spent_on_fire_average As Single
    End Class

    Public Class Hero_Stats9
        Public Property recon_assists_most_in_game As Single
        Public Property scoped_hits As Single
        Public Property scoped_accuracy_best_in_game As Single
        Public Property venom_mine_kills As Single
        Public Property scoped_shots As Single
        Public Property scoped_critical_hits_most_in_game As Single
        Public Property venom_mine_kills_most_in_game As Single
        Public Property scoped_accuracy As Single
        Public Property melee_final_blow_most_in_game As Single
        Public Property scoped_critical_hits As Single
    End Class

    Public Class General_Stats9
        Public Property kill_streak_best As Single
        Public Property weapon_accuracy As Single
        Public Property eliminations As Single
        Public Property medals As Single
        Public Property objective_kills As Single
        Public Property objective_time As Single
        Public Property critical_hits_most_in_life As Single
        Public Property objective_time_most_in_game As Single
        Public Property time_played As Single
        Public Property final_blows_most_in_game As Single
        Public Property shots_fired As Single
        Public Property turrets_destroyed As Single
        Public Property final_blows As Single
        Public Property solo_kills As Single
        Public Property shots_hit As Single
        Public Property time_spent_on_fire As Single
        Public Property environmental_deaths As Single
        Public Property medals_gold As Single
        Public Property eliminations_most_in_life As Single
        Public Property damage_done_most_in_life As Single
        Public Property damage_done As Single
        Public Property objective_kills_most_in_game As Single
        Public Property cards As Single
        Public Property melee_final_blows As Single
        Public Property solo_kills_most_in_game As Single
        Public Property games_won As Single
        Public Property critical_hit_accuracy As Single
        Public Property eliminations_per_life As Single
        Public Property medals_bronze As Single
        Public Property weapon_accuracy_best_in_game As Single
        Public Property medals_silver As Single
        Public Property damage_done_most_in_game As Single
        Public Property eliminations_most_in_game As Single
        Public Property critical_hits As Single
        Public Property deaths As Single
        Public Property critical_hits_most_in_game As Single
    End Class

    Public Class Ana1
        Public Property average_stats As Average_Stats12
        Public Property hero_stats As Hero_Stats10
        Public Property general_stats As General_Stats10
    End Class

    Public Class Average_Stats12
        Public Property enemies_slept_average As Single
        Public Property defensive_assists_average As Single
        Public Property eliminations_average As Single
        Public Property nano_boost_assists_average As Single
        Public Property objective_kills_average As Single
        Public Property solo_kills_average As Single
        Public Property offensive_assists_average As Single
        Public Property healing_done_average As Single
        Public Property self_healing_average As Single
        Public Property melee_final_blows_average As Single
        Public Property nano_boosts_applied_average As Single
        Public Property damage_done_average As Single
        Public Property deaths_average As Single
        Public Property final_blows_average As Single
        Public Property time_spent_on_fire_average As Single
        Public Property objective_time_average As Single
    End Class

    Public Class Hero_Stats10
        Public Property melee_final_blows_most_in_game As Single
        Public Property unscoped_accuracy As Single
        Public Property scoped_hits As Single
        Public Property scoped_accuracy_best_in_game As Single
        Public Property nano_boost_assists_most_in_game As Single
        Public Property nano_boosts_applied As Single
        Public Property scoped_shots As Single
        Public Property nano_boost_assists As Single
        Public Property scoped_accuracy As Single
    End Class

    Public Class General_Stats10
        Public Property enemies_slept_most_in_game As Single
        Public Property eliminations_most_in_game As Single
        Public Property solo_kills_most_in_game As Single
        Public Property objective_kills As Single
        Public Property objective_time As Single
        Public Property turrets_destroyed As Single
        Public Property kill_streak_best As Single
        Public Property shots_fired As Single
        Public Property objective_time_most_in_game As Single
        Public Property final_blows As Single
        Public Property unscoped_shots As Single
        Public Property weapon_accuracy_best_in_game As Single
        Public Property healing_done_most_in_life As Single
        Public Property shots_hit As Single
        Public Property time_spent_on_fire As Single
        Public Property defensive_assists As Single
        Public Property damage_done_most_in_life As Single
        Public Property environmental_deaths As Single
        Public Property medals_gold As Single
        Public Property games_won As Single
        Public Property nano_boosts_applied_most_in_game As Single
        Public Property eliminations_per_life As Single
        Public Property defensive_assists_most_in_game As Single
        Public Property unscoped_hits As Single
        Public Property weapon_accuracy As Single
        Public Property eliminations As Single
        Public Property self_healing As Single
        Public Property self_healing_most_in_game As Single
        Public Property offensive_assists_most_in_game As Single
        Public Property final_blows_most_in_game As Single
        Public Property medals As Single
        Public Property offensive_assists As Single
        Public Property solo_kills As Single
        Public Property unscoped_accuracy_best_in_game As Single
        Public Property melee_final_blows As Single
        Public Property healing_done_most_in_game As Single
        Public Property eliminations_most_in_life As Single
        Public Property damage_done As Single
        Public Property objective_kills_most_in_game As Single
        Public Property cards As Single
        Public Property time_spent_on_fire_most_in_game As Single
        Public Property medals_silver As Single
        Public Property healing_done As Single
        Public Property medals_bronze As Single
        Public Property enemies_slept As Single
        Public Property damage_done_most_in_game As Single
        Public Property deaths As Single
        Public Property time_played As Single
    End Class

    Public Class Winston1
        Public Property average_stats As Average_Stats13
        Public Property hero_stats As Hero_Stats11
        Public Property general_stats As General_Stats11
    End Class

    Public Class Average_Stats13
        Public Property jump_pack_kills_average As Single
        Public Property eliminations_average As Single
        Public Property damage_blocked_average As Single
        Public Property objective_kills_average As Single
        Public Property objective_time_average As Single
        Public Property damage_done_average As Single
        Public Property primal_rage_kills_average As Single
        Public Property melee_final_blows_average As Single
        Public Property melee_kills_average As Single
        Public Property players_knocked_back_average As Single
        Public Property solo_kills_average As Single
        Public Property deaths_average As Single
        Public Property final_blows_average As Single
        Public Property time_spent_on_fire_average As Single
    End Class

    Public Class Hero_Stats11
        Public Property melee_final_blows_most_in_game As Single
        Public Property melee_kills As Single
        Public Property players_knocked_back As Single
        Public Property players_knocked_back_most_in_game As Single
        Public Property jump_pack_kills_most_in_game As Single
        Public Property damage_blocked As Single
        Public Property melee_kills_most_in_game As Single
        Public Property damage_blocked_most_in_game As Single
        Public Property jump_pack_kills As Single
    End Class

    Public Class General_Stats11
        Public Property primal_rage_kills_most_in_game As Single
        Public Property primal_rage_kills As Single
        Public Property multikills As Single
        Public Property eliminations_most_in_game As Single
        Public Property eliminations As Single
        Public Property medals As Single
        Public Property objective_kills As Single
        Public Property objective_time As Single
        Public Property turrets_destroyed As Single
        Public Property time_played As Single
        Public Property final_blows_most_in_game As Single
        Public Property environmental_kills As Single
        Public Property objective_time_most_in_game As Single
        Public Property kill_streak_best As Single
        Public Property final_blows As Single
        Public Property melee_final_blows As Single
        Public Property time_spent_on_fire As Single
        Public Property environmental_deaths As Single
        Public Property medals_gold As Single
        Public Property eliminations_most_in_life As Single
        Public Property damage_done_most_in_life As Single
        Public Property damage_done As Single
        Public Property objective_kills_most_in_game As Single
        Public Property cards As Single
        Public Property solo_kills As Single
        Public Property solo_kills_most_in_game As Single
        Public Property time_spent_on_fire_most_in_game As Single
        Public Property multikill_best As Single
        Public Property games_won As Single
        Public Property medals_bronze As Single
        Public Property eliminations_per_life As Single
        Public Property medals_silver As Single
        Public Property damage_done_most_in_game As Single
        Public Property teleporter_pads_destroyed As Single
        Public Property deaths As Single
    End Class

    Public Class Mei
        Public Property average_stats As Average_Stats14
        Public Property hero_stats As Hero_Stats12
        Public Property general_stats As General_Stats12
    End Class

    Public Class Average_Stats14
        Public Property critical_hits_average As Single
        Public Property melee_final_blows_average As Single
        Public Property enemies_frozen_average As Single
        Public Property objective_kills_average As Single
        Public Property solo_kills_average As Single
        Public Property damage_done_average As Single
        Public Property healing_done_average As Single
        Public Property self_healing_average As Single
        Public Property damage_blocked_average As Single
        Public Property eliminations_average As Single
        Public Property objective_time_average As Single
        Public Property blizzard_kills_average As Single
        Public Property deaths_average As Single
        Public Property final_blows_average As Single
        Public Property time_spent_on_fire_average As Single
    End Class

    Public Class Hero_Stats12
        Public Property blizzard_kills As Single
        Public Property melee_final_blows_most_in_game As Single
        Public Property enemies_frozen As Single
        Public Property enemies_frozen_most_in_game As Single
        Public Property damage_blocked As Single
        Public Property damage_blocked_most_in_game As Single
        Public Property blizzard_kills_most_in_game As Single
    End Class

    Public Class General_Stats12
        Public Property final_blows_most_in_game As Single
        Public Property weapon_accuracy As Single
        Public Property eliminations As Single
        Public Property objective_kills_most_in_game As Single
        Public Property self_healing As Single
        Public Property shots_fired As Single
        Public Property objective_kills As Single
        Public Property objective_time As Single
        Public Property multikill_best As Single
        Public Property objective_time_most_in_game As Single
        Public Property time_played As Single
        Public Property kill_streak_best As Single
        Public Property eliminations_per_life As Single
        Public Property turrets_destroyed As Single
        Public Property final_blows As Single
        Public Property deaths As Single
        Public Property solo_kills As Single
        Public Property healing_done_most_in_life As Single
        Public Property self_healing_most_in_game As Single
        Public Property shots_hit As Single
        Public Property time_spent_on_fire As Single
        Public Property medals_gold As Single
        Public Property healing_done_most_in_game As Single
        Public Property eliminations_most_in_life As Single
        Public Property damage_done_most_in_life As Single
        Public Property damage_done As Single
        Public Property multikill As Single
        Public Property critical_hit_accuracy As Single
        Public Property melee_final_blows As Single
        Public Property solo_kills_most_in_game As Single
        Public Property medals As Single
        Public Property games_won As Single
        Public Property critical_hits As Single
        Public Property critical_hits_most_in_game As Single
        Public Property medals_bronze As Single
        Public Property card As Single
        Public Property weapon_accuracy_best_in_game As Single
        Public Property medals_silver As Single
        Public Property damage_done_most_in_game As Single
        Public Property eliminations_most_in_game As Single
        Public Property critical_hits_most_in_life As Single
        Public Property healing_done As Single
    End Class

    Public Class Tracer
        Public Property average_stats As Average_Stats15
        Public Property hero_stats As Hero_Stats13
        Public Property general_stats As General_Stats13
    End Class

    Public Class Average_Stats15
        Public Property critical_hits_average As Single
        Public Property pulse_bombs_attached_average As Single
        Public Property pulse_bomb_kills_average As Single
        Public Property objective_kills_average As Single
        Public Property objective_time_average As Single
        Public Property damage_done_average As Single
        Public Property self_healing_average As Single
        Public Property melee_final_blows_average As Single
        Public Property solo_kills_average As Single
        Public Property eliminations_average As Single
        Public Property deaths_average As Single
        Public Property final_blows_average As Single
        Public Property time_spent_on_fire_average As Single
    End Class

    Public Class Hero_Stats13
        Public Property melee_final_blows_most_in_game As Single
        Public Property pulse_bomb_kills As Single
        Public Property pulse_bombs_attached As Single
        Public Property pulse_bombs_attached_most_in_game As Single
        Public Property pulse_bomb_kills_most_in_game As Single
    End Class

    Public Class General_Stats13
        Public Property multikills As Single
        Public Property weapon_accuracy As Single
        Public Property eliminations As Single
        Public Property self_healing As Single
        Public Property shots_fired As Single
        Public Property final_blows_most_in_game As Single
        Public Property cards As Single
        Public Property objective_kills As Single
        Public Property objective_time As Single
        Public Property shield_generator_destroyed As Single
        Public Property objective_time_most_in_game As Single
        Public Property time_played As Single
        Public Property kill_streak_best As Single
        Public Property eliminations_per_life As Single
        Public Property turrets_destroyed As Single
        Public Property final_blows As Single
        Public Property eliminations_most_in_game As Single
        Public Property solo_kills As Single
        Public Property multikill_best As Single
        Public Property self_healing_most_in_game As Single
        Public Property shots_hit As Single
        Public Property time_spent_on_fire As Single
        Public Property environmental_deaths As Single
        Public Property medals_gold As Single
        Public Property eliminations_most_in_life As Single
        Public Property damage_done_most_in_life As Single
        Public Property damage_done As Single
        Public Property objective_kills_most_in_game As Single
        Public Property critical_hit_accuracy As Single
        Public Property melee_final_blows As Single
        Public Property solo_kills_most_in_game As Single
        Public Property medals As Single
        Public Property games_won As Single
        Public Property critical_hits As Single
        Public Property critical_hits_most_in_game As Single
        Public Property medals_bronze As Single
        Public Property weapon_accuracy_best_in_game As Single
        Public Property medals_silver As Single
        Public Property damage_done_most_in_game As Single
        Public Property teleporter_pads_destroyed As Single
        Public Property critical_hits_most_in_life As Single
        Public Property deaths As Single
    End Class

    Public Class Orisa
        Public Property average_stats As Average_Stats16
        Public Property hero_stats As Hero_Stats14
        Public Property general_stats As General_Stats14
    End Class

    Public Class Average_Stats16
    End Class

    Public Class Hero_Stats14
    End Class

    Public Class General_Stats14
        Public Property medals_bronze As Single
        Public Property medals_silver As Single
        Public Property time_played As Single
        Public Property medals As Single
    End Class

    Public Class Symmetra
        Public Property average_stats As Average_Stats17
        Public Property hero_stats As Hero_Stats15
        Public Property general_stats As General_Stats15
    End Class

    Public Class Average_Stats17
        Public Property teleporter_uptime_average As Single
        Public Property eliminations_average As Single
        Public Property damage_blocked_average As Single
        Public Property objective_kills_average As Single
        Public Property objective_time_average As Single
        Public Property solo_kills_average As Single
        Public Property sentry_turret_kills_average As Single
        Public Property time_spent_on_fire_average As Single
        Public Property damage_done_average As Single
        Public Property shields_provided_average As Single
        Public Property final_blows_average As Single
        Public Property deaths_average As Single
        Public Property players_teleported_average As Single
    End Class

    Public Class Hero_Stats15
        Public Property shields_provided As Single
        Public Property teleporter_uptime_best_in_game As Single
        Public Property players_teleported As Single
        Public Property sentry_turret_kills_most_in_game As Single
        Public Property players_teleported_most_in_game As Single
        Public Property shields_provided_most_in_game As Single
        Public Property sentry_turret_kills As Single
        Public Property teleporter_uptime As Single
    End Class

    Public Class General_Stats15
        Public Property damage_blocked As Single
        Public Property multikills As Single
        Public Property eliminations_most_in_game As Single
        Public Property eliminations As Single
        Public Property medals As Single
        Public Property damage_blocked_most_in_game As Single
        Public Property objective_kills As Single
        Public Property objective_time As Single
        Public Property time_played As Single
        Public Property final_blows_most_in_game As Single
        Public Property eliminations_per_life As Single
        Public Property objective_time_most_in_game As Single
        Public Property kill_streak_best As Single
        Public Property final_blows As Single
        Public Property environmental_deaths As Single
        Public Property time_spent_on_fire As Single
        Public Property eliminations_most_in_life As Single
        Public Property damage_done_most_in_life As Single
        Public Property damage_done As Single
        Public Property objective_kills_most_in_game As Single
        Public Property cards As Single
        Public Property solo_kills As Single
        Public Property medals_gold As Single
        Public Property multikill_best As Single
        Public Property games_won As Single
        Public Property medals_bronze As Single
        Public Property solo_kills_most_in_game As Single
        Public Property medals_silver As Single
        Public Property damage_done_most_in_game As Single
        Public Property deaths As Single
    End Class

    Public Class Hanzo
        Public Property average_stats As Average_Stats18
        Public Property hero_stats As Hero_Stats16
        Public Property general_stats As General_Stats16
    End Class

    Public Class Average_Stats18
        Public Property critical_hits_average As Single
        Public Property final_blows_average As Single
        Public Property eliminations_average As Single
        Public Property scatter_arrow_kills_average As Single
        Public Property objective_time_average As Single
        Public Property objective_kills_average As Single
        Public Property solo_kills_average As Single
        Public Property dragonstrike_kills_average As Single
        Public Property damage_done_average As Single
        Public Property time_spent_on_fire_average As Single
        Public Property deaths_average As Single
    End Class

    Public Class Hero_Stats16
        Public Property dragonstrike_kills_most_in_game As Single
        Public Property recon_assists_most_in_game As Single
        Public Property dragonstrike_kills As Single
        Public Property scatter_arrow_kills_most_in_game As Single
        Public Property scatter_arrow_kills As Single
    End Class

    Public Class General_Stats16
        Public Property kill_streak_best As Single
        Public Property weapon_accuracy As Single
        Public Property eliminations As Single
        Public Property medals As Single
        Public Property objective_kills As Single
        Public Property objective_time As Single
        Public Property critical_hits_most_in_life As Single
        Public Property turrets_destroyed As Single
        Public Property time_played As Single
        Public Property final_blows_most_in_game As Single
        Public Property shots_fired As Single
        Public Property objective_time_most_in_game As Single
        Public Property final_blows As Single
        Public Property solo_kills As Single
        Public Property card As Single
        Public Property shots_hit As Single
        Public Property time_spent_on_fire As Single
        Public Property medals_gold As Single
        Public Property eliminations_most_in_life As Single
        Public Property damage_done_most_in_life As Single
        Public Property damage_done As Single
        Public Property objective_kills_most_in_game As Single
        Public Property games_won As Single
        Public Property solo_kills_most_in_game As Single
        Public Property critical_hit_accuracy As Single
        Public Property eliminations_per_life As Single
        Public Property medals_bronze As Single
        Public Property weapon_accuracy_best_in_game As Single
        Public Property medals_silver As Single
        Public Property damage_done_most_in_game As Single
        Public Property eliminations_most_in_game As Single
        Public Property critical_hits As Single
        Public Property deaths As Single
        Public Property critical_hits_most_in_game As Single
    End Class

    Public Class Lucio1
        Public Property average_stats As Average_Stats19
        Public Property hero_stats As Hero_Stats17
        Public Property general_stats As General_Stats17
    End Class

    Public Class Average_Stats19
        Public Property critical_hits_average As Single
        Public Property sound_barriers_provided_average As Single
        Public Property defensive_assists_average As Single
        Public Property objective_kills_average As Single
        Public Property solo_kills_average As Single
        Public Property damage_done_average As Single
        Public Property healing_done_average As Single
        Public Property self_healing_average As Single
        Public Property melee_final_blows_average As Single
        Public Property offensive_assists_average As Single
        Public Property eliminations_average As Single
        Public Property deaths_average As Single
        Public Property final_blows_average As Single
        Public Property time_spent_on_fire_average As Single
        Public Property objective_time_average As Single
    End Class

    Public Class Hero_Stats17
        Public Property melee_final_blows_most_in_game As Single
        Public Property sound_barriers_provided_most_in_game As Single
        Public Property sound_barriers_provided As Single
    End Class

    Public Class General_Stats17
        Public Property defensive_assists As Single
        Public Property eliminations_most_in_game As Single
        Public Property multikill As Single
        Public Property medals As Single
        Public Property objective_kills As Single
        Public Property objective_time As Single
        Public Property turrets_destroyed As Single
        Public Property kill_streak_best As Single
        Public Property shots_fired As Single
        Public Property objective_time_most_in_game As Single
        Public Property final_blows As Single
        Public Property healing_done_most_in_life As Single
        Public Property shots_hit As Single
        Public Property offensive_assists As Single
        Public Property medals_gold As Single
        Public Property damage_done_most_in_life As Single
        Public Property defensive_assists_most_in_game As Single
        Public Property environmental_deaths As Single
        Public Property solo_kills_most_in_game As Single
        Public Property multikill_best As Single
        Public Property critical_hit_accuracy As Single
        Public Property critical_hits_most_in_game As Single
        Public Property eliminations_per_life As Single
        Public Property games_won As Single
        Public Property weapon_accuracy_best_in_game As Single
        Public Property medals_silver As Single
        Public Property teleporter_pads_destroyed As Single
        Public Property critical_hits_most_in_life As Single
        Public Property weapon_accuracy As Single
        Public Property eliminations As Single
        Public Property self_healing As Single
        Public Property self_healing_most_in_game As Single
        Public Property offensive_assists_most_in_game As Single
        Public Property final_blows_most_in_game As Single
        Public Property environmental_kills As Single
        Public Property time_spent_on_fire As Single
        Public Property solo_kills As Single
        Public Property melee_final_blows As Single
        Public Property healing_done_most_in_game As Single
        Public Property eliminations_most_in_life As Single
        Public Property damage_done As Single
        Public Property objective_kills_most_in_game As Single
        Public Property cards As Single
        Public Property time_spent_on_fire_most_in_game As Single
        Public Property critical_hits As Single
        Public Property healing_done As Single
        Public Property medals_bronze As Single
        Public Property damage_done_most_in_game As Single
        Public Property deaths As Single
        Public Property time_played As Single
    End Class

    Public Class Mercy
        Public Property average_stats As Average_Stats20
        Public Property hero_stats As Hero_Stats18
        Public Property general_stats As General_Stats18
    End Class

    Public Class Average_Stats20
        Public Property critical_hits_average As Single
        Public Property eliminations_average As Single
        Public Property defensive_assists_average As Single
        Public Property objective_kills_average As Single
        Public Property solo_kills_average As Single
        Public Property damage_done_average As Single
        Public Property healing_done_average As Single
        Public Property self_healing_average As Single
        Public Property damage_amplified_average As Single
        Public Property melee_final_blows_average As Single
        Public Property offensive_assists_average As Single
        Public Property players_resurrected_average As Single
        Public Property deaths_average As Single
        Public Property final_blows_average As Single
        Public Property blaster_kills_average As Single
        Public Property time_spent_on_fire_average As Single
        Public Property objective_time_average As Single
    End Class

    Public Class Hero_Stats18
        Public Property players_resurrected_most_in_game As Single
        Public Property players_resurrected As Single
        Public Property melee_final_blow_most_in_game As Single
    End Class

    Public Class General_Stats18
        Public Property damage_amplified As Single
        Public Property eliminations_most_in_game As Single
        Public Property solo_kills_most_in_game As Single
        Public Property objective_kills As Single
        Public Property objective_time As Single
        Public Property turrets_destroyed As Single
        Public Property kill_streak_best As Single
        Public Property shots_fired As Single
        Public Property objective_time_most_in_game As Single
        Public Property final_blows As Single
        Public Property weapon_accuracy_best_in_game As Single
        Public Property healing_done_most_in_life As Single
        Public Property blaster_kills_most_in_game As Single
        Public Property shots_hit As Single
        Public Property time_spent_on_fire As Single
        Public Property defensive_assists As Single
        Public Property damage_done_most_in_life As Single
        Public Property defensive_assists_most_in_game As Single
        Public Property melee_final_blows As Single
        Public Property medals_gold As Single
        Public Property critical_hit_accuracy As Single
        Public Property eliminations_per_life As Single
        Public Property games_won As Single
        Public Property critical_hits_most_in_life As Single
        Public Property medals_silver As Single
        Public Property critical_hits_most_in_game As Single
        Public Property weapon_accuracy As Single
        Public Property eliminations As Single
        Public Property self_healing As Single
        Public Property damage_amplified_most_in_game As Single
        Public Property self_healing_most_in_game As Single
        Public Property shield_generator_destroyed As Single
        Public Property offensive_assists_most_in_game As Single
        Public Property final_blows_most_in_game As Single
        Public Property medals As Single
        Public Property offensive_assists As Single
        Public Property solo_kills As Single
        Public Property blaster_kills As Single
        Public Property healing_done_most_in_game As Single
        Public Property eliminations_most_in_life As Single
        Public Property damage_done As Single
        Public Property objective_kills_most_in_game As Single
        Public Property cards As Single
        Public Property critical_hits As Single
        Public Property healing_done As Single
        Public Property medals_bronze As Single
        Public Property environmental_death As Single
        Public Property damage_done_most_in_game As Single
        Public Property deaths As Single
        Public Property time_played As Single
    End Class

    Public Class Sombra
        Public Property average_stats As Average_Stats21
        Public Property hero_stats As Hero_Stats19
        Public Property general_stats As General_Stats19
    End Class

    Public Class Average_Stats21
    End Class

    Public Class Hero_Stats19
    End Class

    Public Class General_Stats19
        Public Property medals_bronze As Single
        Public Property medals_silver As Single
        Public Property medals As Single
        Public Property time_played As Single
        Public Property shots_fired As Single
    End Class

    Public Class Mccree
        Public Property average_stats As Average_Stats22
        Public Property hero_stats As Hero_Stats20
        Public Property general_stats As General_Stats20
    End Class

    Public Class Average_Stats22
        Public Property critical_hits_average As Single
        Public Property fan_the_hammer_kills_average As Single
        Public Property eliminations_average As Single
        Public Property objective_kills_average As Single
        Public Property objective_time_average As Single
        Public Property solo_kills_average As Single
        Public Property deadeye_kills_average As Single
        Public Property melee_final_blows_average As Single
        Public Property damage_done_average As Single
        Public Property deaths_average As Single
        Public Property final_blows_average As Single
        Public Property time_spent_on_fire_average As Single
    End Class

    Public Class Hero_Stats20
        Public Property melee_final_blows_most_in_game As Single
        Public Property deadeye_kills_most_in_game As Single
        Public Property fan_the_hammer_kills As Single
        Public Property deadeye_kills As Single
    End Class

    Public Class General_Stats20
        Public Property final_blows_most_in_game As Single
        Public Property weapon_accuracy As Single
        Public Property eliminations As Single
        Public Property objective_kills_most_in_game As Single
        Public Property multikill_best As Single
        Public Property shots_fired As Single
        Public Property objective_kills As Single
        Public Property objective_time As Single
        Public Property shield_generator_destroyed As Single
        Public Property objective_time_most_in_game As Single
        Public Property offensive_assists_most_in_game As Single
        Public Property kill_streak_best As Single
        Public Property eliminations_per_life As Single
        Public Property turrets_destroyed As Single
        Public Property final_blows As Single
        Public Property solo_kills As Single
        Public Property games_won As Single
        Public Property card As Single
        Public Property fan_the_hammer_kills_most_in_game As Single
        Public Property shots_hit As Single
        Public Property time_spent_on_fire As Single
        Public Property environmental_deaths As Single
        Public Property medals_gold As Single
        Public Property eliminations_most_in_life As Single
        Public Property damage_done_most_in_life As Single
        Public Property damage_done As Single
        Public Property multikill As Single
        Public Property critical_hit_accuracy As Single
        Public Property time_spent_on_fire_most_in_game As Single
        Public Property melee_final_blows As Single
        Public Property solo_kills_most_in_game As Single
        Public Property medals As Single
        Public Property medals_silver As Single
        Public Property critical_hits As Single
        Public Property critical_hits_most_in_game As Single
        Public Property medals_bronze As Single
        Public Property weapon_accuracy_best_in_game As Single
        Public Property teleporter_pad_destroyed As Single
        Public Property damage_done_most_in_game As Single
        Public Property eliminations_most_in_game As Single
        Public Property critical_hits_most_in_life As Single
        Public Property deaths As Single
        Public Property time_played As Single
    End Class

    Public Class Reaper
        Public Property average_stats As Average_Stats23
        Public Property hero_stats As Hero_Stats21
        Public Property general_stats As General_Stats21
    End Class

    Public Class Average_Stats23
        Public Property critical_hits_average As Single
        Public Property eliminations_average As Single
        Public Property objective_kills_average As Single
        Public Property objective_time_average As Single
        Public Property damage_done_average As Single
        Public Property healing_done_average As Single
        Public Property self_healing_average As Single
        Public Property final_blows_average As Single
        Public Property solo_kills_average As Single
        Public Property deaths_average As Single
        Public Property souls_consumed_average As Single
        Public Property time_spent_on_fire_average As Single
        Public Property death_blossom_kills_average As Single
    End Class

    Public Class Hero_Stats21
        Public Property death_blossom_kills As Single
        Public Property death_blossom_kills_most_in_game As Single
        Public Property souls_consumed As Single
        Public Property souls_consumed_most_in_game As Single
    End Class

    Public Class General_Stats21
        Public Property final_blows_most_in_game As Single
        Public Property weapon_accuracy As Single
        Public Property eliminations As Single
        Public Property self_healing As Single
        Public Property medals As Single
        Public Property objective_kills As Single
        Public Property objective_time As Single
        Public Property critical_hits_most_in_life As Single
        Public Property time_played As Single
        Public Property kill_streak_best As Single
        Public Property shots_fired As Single
        Public Property objective_time_most_in_game As Single
        Public Property final_blows As Single
        Public Property deaths As Single
        Public Property solo_kills As Single
        Public Property healing_done_most_in_life As Single
        Public Property self_healing_most_in_game As Single
        Public Property shots_hit As Single
        Public Property time_spent_on_fire As Single
        Public Property medals_gold As Single
        Public Property healing_done_most_in_game As Single
        Public Property eliminations_most_in_life As Single
        Public Property damage_done_most_in_life As Single
        Public Property damage_done As Single
        Public Property objective_kills_most_in_game As Single
        Public Property turret_destroyed As Single
        Public Property games_won As Single
        Public Property solo_kills_most_in_game As Single
        Public Property critical_hit_accuracy As Single
        Public Property eliminations_per_life As Single
        Public Property medals_bronze As Single
        Public Property weapon_accuracy_best_in_game As Single
        Public Property medals_silver As Single
        Public Property damage_done_most_in_game As Single
        Public Property eliminations_most_in_game As Single
        Public Property critical_hits As Single
        Public Property healing_done As Single
        Public Property critical_hits_most_in_game As Single
    End Class

    Public Class Genji
        Public Property average_stats As Average_Stats24
        Public Property hero_stats As Hero_Stats22
        Public Property general_stats As General_Stats22
    End Class

    Public Class Average_Stats24
        Public Property critical_hits_average As Single
        Public Property eliminations_average As Single
        Public Property objective_kills_average As Single
        Public Property objective_time_average As Single
        Public Property damage_done_average As Single
        Public Property melee_final_blows_average As Single
        Public Property damage_reflected_average As Single
        Public Property dragonblade_kills_average As Single
        Public Property solo_kills_average As Single
        Public Property deaths_average As Single
        Public Property final_blows_average As Single
        Public Property time_spent_on_fire_average As Single
    End Class

    Public Class Hero_Stats22
        Public Property melee_final_blows_most_in_game As Single
        Public Property dragonblade_kills_most_in_game As Single
        Public Property dragonblade_kills As Single
        Public Property damage_reflected As Single
        Public Property dragonblades As Single
        Public Property damage_reflected_most_in_game As Single
    End Class

    Public Class General_Stats22
        Public Property multikills As Single
        Public Property weapon_accuracy As Single
        Public Property eliminations As Single
        Public Property time_spent_on_fire_most_in_game As Single
        Public Property multikill_best As Single
        Public Property shots_fired As Single
        Public Property cards As Single
        Public Property objective_kills As Single
        Public Property objective_time As Single
        Public Property shield_generator_destroyed As Single
        Public Property objective_time_most_in_game As Single
        Public Property time_played As Single
        Public Property final_blows_most_in_game As Single
        Public Property eliminations_per_life As Single
        Public Property turrets_destroyed As Single
        Public Property kill_streak_best As Single
        Public Property final_blows As Single
        Public Property solo_kills As Single
        Public Property shots_hit As Single
        Public Property time_spent_on_fire As Single
        Public Property environmental_deaths As Single
        Public Property medals_gold As Single
        Public Property eliminations_most_in_life As Single
        Public Property damage_done_most_in_life As Single
        Public Property damage_done As Single
        Public Property objective_kills_most_in_game As Single
        Public Property critical_hit_accuracy As Single
        Public Property melee_final_blows As Single
        Public Property solo_kills_most_in_game As Single
        Public Property medals As Single
        Public Property games_won As Single
        Public Property critical_hits As Single
        Public Property critical_hits_most_in_game As Single
        Public Property medals_bronze As Single
        Public Property weapon_accuracy_best_in_game As Single
        Public Property medals_silver As Single
        Public Property damage_done_most_in_game As Single
        Public Property eliminations_most_in_game As Single
        Public Property critical_hits_most_in_life As Single
        Public Property deaths As Single
    End Class

    Public Class Zenyatta
        Public Property average_stats As Average_Stats25
        Public Property hero_stats As Hero_Stats23
        Public Property general_stats As General_Stats23
    End Class

    Public Class Average_Stats25
        Public Property critical_hits_average As Single
        Public Property eliminations_average As Single
        Public Property defensive_assists_average As Single
        Public Property objective_kills_average As Single
        Public Property objective_time_average As Single
        Public Property offensive_assists_average As Single
        Public Property healing_done_average As Single
        Public Property self_healing_average As Single
        Public Property final_blows_average As Single
        Public Property damage_done_average As Single
        Public Property solo_kills_average As Single
        Public Property deaths_average As Single
        Public Property time_spent_on_fire_average As Single
    End Class

    Public Class Hero_Stats23
        Public Property transcendence_healing_best As Single
    End Class

    Public Class General_Stats23
        Public Property eliminations_most_in_game As Single
        Public Property solo_kills_most_in_game As Single
        Public Property objective_kills As Single
        Public Property objective_time As Single
        Public Property turrets_destroyed As Single
        Public Property kill_streak_best As Single
        Public Property shots_fired As Single
        Public Property objective_time_most_in_game As Single
        Public Property final_blows As Single
        Public Property weapon_accuracy_best_in_game As Single
        Public Property healing_done_most_in_life As Single
        Public Property shots_hit As Single
        Public Property time_spent_on_fire As Single
        Public Property transcendence_healing As Single
        Public Property defensive_assists As Single
        Public Property damage_done_most_in_life As Single
        Public Property defensive_assists_most_in_game As Single
        Public Property medals_gold As Single
        Public Property critical_hit_accuracy As Single
        Public Property eliminations_per_life As Single
        Public Property games_won As Single
        Public Property critical_hits_most_in_life As Single
        Public Property medals_silver As Single
        Public Property critical_hits_most_in_game As Single
        Public Property weapon_accuracy As Single
        Public Property eliminations As Single
        Public Property self_healing As Single
        Public Property self_healing_most_in_game As Single
        Public Property offensive_assists_most_in_game As Single
        Public Property final_blows_most_in_game As Single
        Public Property medals As Single
        Public Property offensive_assists As Single
        Public Property solo_kills As Single
        Public Property healing_done_most_in_game As Single
        Public Property eliminations_most_in_life As Single
        Public Property damage_done As Single
        Public Property objective_kills_most_in_game As Single
        Public Property cards As Single
        Public Property critical_hits As Single
        Public Property healing_done As Single
        Public Property medals_bronze As Single
        Public Property environmental_death As Single
        Public Property damage_done_most_in_game As Single
        Public Property deaths As Single
        Public Property time_played As Single
    End Class

    Public Class Bastion
        Public Property average_stats As Average_Stats26
        Public Property hero_stats As Hero_Stats24
        Public Property general_stats As General_Stats24
    End Class

    Public Class Average_Stats26
        Public Property critical_hits_average As Single
        Public Property eliminations_average As Single
        Public Property recon_kills_average As Single
        Public Property objective_kills_average As Single
        Public Property objective_time_average As Single
        Public Property damage_done_average As Single
        Public Property healing_done_average As Single
        Public Property self_healing_average As Single
        Public Property final_blows_average As Single
        Public Property tank_kills_average As Single
        Public Property sentry_kills_average As Single
        Public Property solo_kills_average As Single
        Public Property deaths_average As Single
    End Class

    Public Class Hero_Stats24
        Public Property sentry_kills As Single
        Public Property recon_kill_most_in_game As Single
        Public Property tank_kills_most_in_game As Single
        Public Property tank_kills As Single
        Public Property recon_kills As Single
        Public Property sentry_kills_most_in_game As Single
    End Class

    Public Class General_Stats24
        Public Property final_blows_most_in_game As Single
        Public Property weapon_accuracy As Single
        Public Property eliminations As Single
        Public Property objective_kills_most_in_game As Single
        Public Property self_healing As Single
        Public Property medals As Single
        Public Property objective_kills As Single
        Public Property objective_time As Single
        Public Property critical_hits_most_in_life As Single
        Public Property time_played As Single
        Public Property kill_streak_best As Single
        Public Property shots_fired As Single
        Public Property objective_time_most_in_game As Single
        Public Property final_blows As Single
        Public Property deaths As Single
        Public Property solo_kills As Single
        Public Property healing_done_most_in_life As Single
        Public Property self_healing_most_in_game As Single
        Public Property shots_hit As Single
        Public Property medals_gold As Single
        Public Property healing_done_most_in_game As Single
        Public Property eliminations_most_in_life As Single
        Public Property damage_done_most_in_life As Single
        Public Property damage_done As Single
        Public Property multikill As Single
        Public Property games_won As Single
        Public Property solo_kills_most_in_game As Single
        Public Property multikill_best As Single
        Public Property critical_hit_accuracy As Single
        Public Property eliminations_per_life As Single
        Public Property medals_bronze As Single
        Public Property card As Single
        Public Property weapon_accuracy_best_in_game As Single
        Public Property medals_silver As Single
        Public Property damage_done_most_in_game As Single
        Public Property eliminations_most_in_game As Single
        Public Property critical_hits As Single
        Public Property healing_done As Single
        Public Property critical_hits_most_in_game As Single
    End Class

    Public Class Zarya1
        Public Property average_stats As Average_Stats27
        Public Property hero_stats As Hero_Stats25
        Public Property general_stats As General_Stats25
    End Class

    Public Class Average_Stats27
        Public Property graviton_surge_kills_average As Single
        Public Property melee_final_blows_average As Single
        Public Property projected_barriers_applied_average As Single
        Public Property objective_kills_average As Single
        Public Property solo_kills_average As Single
        Public Property damage_done_average As Single
        Public Property lifetime_average_energy As Single
        Public Property damage_blocked_average As Single
        Public Property eliminations_average As Single
        Public Property high_energy_kills_average As Single
        Public Property objective_time_average As Single
        Public Property average_energy_best_in_game As Single
        Public Property deaths_average As Single
        Public Property final_blows_average As Single
        Public Property time_spent_on_fire_average As Single
    End Class

    Public Class Hero_Stats25
        Public Property graviton_surge_kills_most_in_game As Single
        Public Property lifetime_energy_accumulation As Single
        Public Property melee_final_blow_most_in_game As Single
        Public Property high_energy_kills_most_in_game As Single
        Public Property lifetime_graviton_surge_kills As Single
        Public Property projected_barriers_applied As Single
        Public Property damage_blocked As Single
        Public Property high_energy_kills As Single
        Public Property damage_blocked_most_in_game As Single
        Public Property energy_maximum As Single
    End Class

    Public Class General_Stats25
        Public Property projected_barriers_applied_most_in_game As Single
        Public Property multikills As Single
        Public Property weapon_accuracy As Single
        Public Property eliminations As Single
        Public Property environmental_deaths As Single
        Public Property multikill_best As Single
        Public Property medals As Single
        Public Property objective_kills As Single
        Public Property objective_time As Single
        Public Property objective_time_most_in_game As Single
        Public Property time_played As Single
        Public Property final_blows_most_in_game As Single
        Public Property shots_fired As Single
        Public Property turrets_destroyed As Single
        Public Property kill_streak_best As Single
        Public Property final_blows As Single
        Public Property solo_kills As Single
        Public Property environmental_kill As Single
        Public Property shots_hit As Single
        Public Property time_spent_on_fire As Single
        Public Property melee_final_blows As Single
        Public Property medals_gold As Single
        Public Property eliminations_most_in_life As Single
        Public Property damage_done_most_in_life As Single
        Public Property damage_done As Single
        Public Property objective_kills_most_in_game As Single
        Public Property cards As Single
        Public Property teleporter_pads_destroyed As Single
        Public Property solo_kills_most_in_game As Single
        Public Property time_spent_on_fire_most_in_game As Single
        Public Property games_won As Single
        Public Property eliminations_per_life As Single
        Public Property medals_bronze As Single
        Public Property weapon_accuracy_best_in_game As Single
        Public Property medals_silver As Single
        Public Property damage_done_most_in_game As Single
        Public Property eliminations_most_in_game As Single
        Public Property deaths As Single
    End Class

    Public Class Roadhog1
        Public Property average_stats As Average_Stats28
        Public Property hero_stats As Hero_Stats26
        Public Property general_stats As General_Stats26
    End Class

    Public Class Average_Stats28
        Public Property critical_hits_average As Single
        Public Property enemies_hooked_average As Single
        Public Property eliminations_average As Single
        Public Property objective_kills_average As Single
        Public Property objective_time_average As Single
        Public Property damage_done_average As Single
        Public Property self_healing_average As Single
        Public Property healing_done_average As Single
        Public Property whole_hog_kills_average As Single
        Public Property melee_final_blows_average As Single
        Public Property solo_kills_average As Single
        Public Property deaths_average As Single
        Public Property final_blows_average As Single
        Public Property time_spent_on_fire_average As Single
    End Class

    Public Class Hero_Stats26
        Public Property melee_final_blows_most_in_game As Single
        Public Property whole_hog_kills As Single
        Public Property hook_accuracy_best_in_game As Single
        Public Property hook_accuracy As Single
        Public Property enemies_hooked_most_in_game As Single
        Public Property enemies_hooked As Single
        Public Property hooks_attempted As Single
        Public Property whole_hog_kills_most_in_game As Single
    End Class

    Public Class General_Stats26
        Public Property eliminations_most_in_game As Single
        Public Property solo_kills_most_in_game As Single
        Public Property medals As Single
        Public Property objective_kills As Single
        Public Property objective_time As Single
        Public Property turrets_destroyed As Single
        Public Property kill_streak_best As Single
        Public Property shots_fired As Single
        Public Property objective_time_most_in_game As Single
        Public Property final_blows As Single
        Public Property weapon_accuracy_best_in_game As Single
        Public Property healing_done_most_in_life As Single
        Public Property shots_hit As Single
        Public Property time_spent_on_fire As Single
        Public Property damage_done_most_in_life As Single
        Public Property environmental_deaths As Single
        Public Property medals_gold As Single
        Public Property multikill_best As Single
        Public Property critical_hit_accuracy As Single
        Public Property critical_hits_most_in_game As Single
        Public Property games_won As Single
        Public Property eliminations_per_life As Single
        Public Property medals_silver As Single
        Public Property critical_hits_most_in_life As Single
        Public Property multikills As Single
        Public Property weapon_accuracy As Single
        Public Property eliminations As Single
        Public Property self_healing As Single
        Public Property self_healing_most_in_game As Single
        Public Property time_played As Single
        Public Property final_blows_most_in_game As Single
        Public Property environmental_kills As Single
        Public Property solo_kills As Single
        Public Property melee_final_blows As Single
        Public Property healing_done_most_in_game As Single
        Public Property eliminations_most_in_life As Single
        Public Property damage_done As Single
        Public Property objective_kills_most_in_game As Single
        Public Property cards As Single
        Public Property time_spent_on_fire_most_in_game As Single
        Public Property critical_hits As Single
        Public Property healing_done As Single
        Public Property medals_bronze As Single
        Public Property damage_done_most_in_game As Single
        Public Property deaths As Single
    End Class

    Public Class Reinhardt1
        Public Property average_stats As Average_Stats29
        Public Property hero_stats As Hero_Stats27
        Public Property general_stats As General_Stats27
    End Class

    Public Class Average_Stats29
        Public Property earthshatter_kills_average As Single
        Public Property damage_done_average As Single
        Public Property objective_kills_average As Single
        Public Property objective_time_average As Single
        Public Property solo_kills_average As Single
        Public Property fire_strike_kills_average As Single
        Public Property charge_kills_average As Single
        Public Property damage_blocked_average As Single
        Public Property offensive_assists_average As Single
        Public Property eliminations_average As Single
        Public Property deaths_average As Single
        Public Property final_blows_average As Single
        Public Property time_spent_on_fire_average As Single
    End Class

    Public Class Hero_Stats27
        Public Property fire_strike_kills_most_in_game As Single
        Public Property earthshatter_kills As Single
        Public Property damage_blocked_most_in_game As Single
        Public Property fire_strike_kills As Single
        Public Property charge_kills_most_in_game As Single
        Public Property damage_blocked As Single
        Public Property earthshatter_kills_most_in_game As Single
        Public Property charge_kills As Single
    End Class

    Public Class General_Stats27
        Public Property multikills As Single
        Public Property eliminations_most_in_game As Single
        Public Property eliminations As Single
        Public Property multikill_best As Single
        Public Property medals As Single
        Public Property objective_kills As Single
        Public Property objective_time As Single
        Public Property turrets_destroyed As Single
        Public Property time_played As Single
        Public Property final_blows_most_in_game As Single
        Public Property environmental_kills As Single
        Public Property objective_time_most_in_game As Single
        Public Property kill_streak_best As Single
        Public Property final_blows As Single
        Public Property solo_kills As Single
        Public Property time_spent_on_fire As Single
        Public Property offensive_assists As Single
        Public Property medals_gold As Single
        Public Property eliminations_most_in_life As Single
        Public Property damage_done_most_in_life As Single
        Public Property damage_done As Single
        Public Property objective_kills_most_in_game As Single
        Public Property cards As Single
        Public Property environmental_deaths As Single
        Public Property solo_kills_most_in_game As Single
        Public Property time_spent_on_fire_most_in_game As Single
        Public Property games_won As Single
        Public Property offensive_assist_most_in_game As Single
        Public Property medals_bronze As Single
        Public Property eliminations_per_life As Single
        Public Property medals_silver As Single
        Public Property damage_done_most_in_game As Single
        Public Property teleporter_pads_destroyed As Single
        Public Property deaths As Single
    End Class

    Public Class Soldier761
        Public Property average_stats As Average_Stats30
        Public Property hero_stats As Hero_Stats28
        Public Property general_stats As General_Stats28
    End Class

    Public Class Average_Stats30
        Public Property critical_hits_average As Single
        Public Property helix_rockets_kills_average As Single
        Public Property eliminations_average As Single
        Public Property objective_kills_average As Single
        Public Property solo_kills_average As Single
        Public Property damage_done_average As Single
        Public Property healing_done_average As Single
        Public Property self_healing_average As Single
        Public Property melee_final_blows_average As Single
        Public Property tactical_visor_kills_average As Single
        Public Property deaths_average As Single
        Public Property final_blows_average As Single
        Public Property time_spent_on_fire_average As Single
        Public Property objective_time_average As Single
    End Class

    Public Class Hero_Stats28
        Public Property melee_final_blows_most_in_game As Single
        Public Property tactical_visor_kills As Single
        Public Property tactical_visor_kills_most_in_game As Single
        Public Property biotic_fields_deployed As Single
        Public Property helix_rockets_kills_most_in_game As Single
        Public Property biotic_field_healing_done As Single
        Public Property helix_rockets_kills As Single
    End Class

    Public Class General_Stats28
        Public Property eliminations_most_in_game As Single
        Public Property objective_kills As Single
        Public Property objective_time As Single
        Public Property turrets_destroyed As Single
        Public Property kill_streak_best As Single
        Public Property shots_fired As Single
        Public Property objective_time_most_in_game As Single
        Public Property final_blows As Single
        Public Property healing_done_most_in_life As Single
        Public Property environmental_kill As Single
        Public Property shots_hit As Single
        Public Property time_spent_on_fire As Single
        Public Property medals_gold As Single
        Public Property damage_done_most_in_life As Single
        Public Property environmental_deaths As Single
        Public Property solo_kills_most_in_game As Single
        Public Property multikill_best As Single
        Public Property critical_hit_accuracy As Single
        Public Property critical_hits_most_in_game As Single
        Public Property eliminations_per_life As Single
        Public Property games_won As Single
        Public Property weapon_accuracy_best_in_game As Single
        Public Property medals_silver As Single
        Public Property teleporter_pads_destroyed As Single
        Public Property critical_hits_most_in_life As Single
        Public Property multikills As Single
        Public Property weapon_accuracy As Single
        Public Property eliminations As Single
        Public Property self_healing As Single
        Public Property self_healing_most_in_game As Single
        Public Property time_played As Single
        Public Property final_blows_most_in_game As Single
        Public Property medals As Single
        Public Property solo_kills As Single
        Public Property melee_final_blows As Single
        Public Property healing_done_most_in_game As Single
        Public Property eliminations_most_in_life As Single
        Public Property damage_done As Single
        Public Property objective_kills_most_in_game As Single
        Public Property cards As Single
        Public Property time_spent_on_fire_most_in_game As Single
        Public Property critical_hits As Single
        Public Property healing_done As Single
        Public Property medals_bronze As Single
        Public Property damage_done_most_in_game As Single
        Public Property deaths As Single
    End Class

    Public Class Dva
        Public Property average_stats As Average_Stats31
        Public Property hero_stats As Hero_Stats29
        Public Property general_stats As General_Stats29
    End Class

    Public Class Average_Stats31
        Public Property critical_hits_average As Single
        Public Property mechs_called_average As Single
        Public Property eliminations_average As Single
        Public Property objective_kills_average As Single
        Public Property objective_time_average As Single
        Public Property solo_kills_average As Single
        Public Property damage_blocked_average As Single
        Public Property damage_done_average As Single
        Public Property self_destruct_kills_average As Single
        Public Property deaths_average As Single
        Public Property final_blows_average As Single
        Public Property time_spent_on_fire_average As Single
    End Class

    Public Class Hero_Stats29
        Public Property mechs_called As Single
        Public Property damage_blocked As Single
        Public Property mechs_called_most_in_game As Single
        Public Property damage_blocked_most_in_game As Single
        Public Property mech_deaths As Single
    End Class

    Public Class General_Stats29
        Public Property kill_streak_best As Single
        Public Property self_destruct_kills_most_in_game As Single
        Public Property weapon_accuracy As Single
        Public Property eliminations As Single
        Public Property objective_kills_most_in_game As Single
        Public Property multikill_best As Single
        Public Property shots_fired As Single
        Public Property objective_kills As Single
        Public Property objective_time As Single
        Public Property objective_time_most_in_game As Single
        Public Property time_played As Single
        Public Property final_blows_most_in_game As Single
        Public Property eliminations_per_life As Single
        Public Property self_destruct_kills As Single
        Public Property turrets_destroyed As Single
        Public Property final_blows As Single
        Public Property solo_kills As Single
        Public Property card As Single
        Public Property environmental_kill As Single
        Public Property shots_hit As Single
        Public Property time_spent_on_fire As Single
        Public Property medals_gold As Single
        Public Property eliminations_most_in_life As Single
        Public Property damage_done_most_in_life As Single
        Public Property damage_done As Single
        Public Property multikill As Single
        Public Property critical_hit_accuracy As Single
        Public Property environmental_deaths As Single
        Public Property solo_kills_most_in_game As Single
        Public Property medals As Single
        Public Property games_won As Single
        Public Property critical_hits As Single
        Public Property critical_hits_most_in_game As Single
        Public Property medals_bronze As Single
        Public Property weapon_accuracy_best_in_game As Single
        Public Property medals_silver As Single
        Public Property damage_done_most_in_game As Single
        Public Property eliminations_most_in_game As Single
        Public Property critical_hits_most_in_life As Single
        Public Property deaths As Single
    End Class

    Public Class Junkrat1
        Public Property average_stats As Average_Stats32
        Public Property hero_stats As Hero_Stats30
        Public Property general_stats As General_Stats30
    End Class

    Public Class Average_Stats32
        Public Property melee_final_blows_average As Single
        Public Property eliminations_average As Single
        Public Property damage_done_average As Single
        Public Property rip_tire_kills_average As Single
        Public Property solo_kills_average As Single
        Public Property objective_kills_average As Single
        Public Property objective_time_average As Single
        Public Property deaths_average As Single
        Public Property offensive_assists_average As Single
        Public Property time_spent_on_fire_average As Single
        Public Property final_blows_average As Single
    End Class

    Public Class Hero_Stats30
        Public Property rip_tire_kills_most_in_game As Single
        Public Property enemies_trapped_a_minute As Single
        Public Property enemies_trapped_most_in_game As Single
        Public Property enemies_trapped As Single
        Public Property rip_tire_kills As Single
        Public Property melee_final_blow_most_in_game As Single
    End Class

    Public Class General_Stats30
        Public Property multikills As Single
        Public Property weapon_accuracy As Single
        Public Property eliminations As Single
        Public Property time_spent_on_fire_most_in_game As Single
        Public Property multikill_best As Single
        Public Property environmental_kills As Single
        Public Property final_blows_most_in_game As Single
        Public Property objective_kills As Single
        Public Property objective_time As Single
        Public Property shield_generator_destroyed As Single
        Public Property objective_time_most_in_game As Single
        Public Property time_played As Single
        Public Property kill_streak_best As Single
        Public Property shots_fired As Single
        Public Property turrets_destroyed As Single
        Public Property final_blows As Single
        Public Property offensive_assist As Single
        Public Property solo_kills As Single
        Public Property shots_hit As Single
        Public Property time_spent_on_fire As Single
        Public Property environmental_deaths As Single
        Public Property medals_gold As Single
        Public Property eliminations_most_in_life As Single
        Public Property damage_done_most_in_life As Single
        Public Property damage_done As Single
        Public Property objective_kills_most_in_game As Single
        Public Property cards As Single
        Public Property teleporter_pads_destroyed As Single
        Public Property solo_kills_most_in_game As Single
        Public Property medals As Single
        Public Property games_won As Single
        Public Property eliminations_per_life As Single
        Public Property melee_final_blow As Single
        Public Property medals_bronze As Single
        Public Property weapon_accuracy_best_in_game As Single
        Public Property medals_silver As Single
        Public Property damage_done_most_in_game As Single
        Public Property eliminations_most_in_game As Single
        Public Property deaths As Single
        Public Property offensive_assist_most_in_game As Single
    End Class

    Public Class Pharah1
        Public Property average_stats As Average_Stats33
        Public Property hero_stats As Hero_Stats31
        Public Property general_stats As General_Stats31
    End Class

    Public Class Average_Stats33
        Public Property rocket_direct_hits_average As Single
        Public Property melee_final_blows_average As Single
        Public Property eliminations_average As Single
        Public Property damage_done_average As Single
        Public Property objective_time_average As Single
        Public Property objective_kills_average As Single
        Public Property solo_kills_average As Single
        Public Property deaths_average As Single
        Public Property barrage_kills_average As Single
        Public Property time_spent_on_fire_average As Single
        Public Property final_blows_average As Single
    End Class

    Public Class Hero_Stats31
        Public Property rocket_direct_hits_most_in_game As Single
        Public Property rocket_direct_hits As Single
        Public Property barrage_kills As Single
        Public Property melee_final_blow_most_in_game As Single
        Public Property barrage_kills_most_in_game As Single
    End Class

    Public Class General_Stats31
        Public Property multikills As Single
        Public Property weapon_accuracy As Single
        Public Property eliminations As Single
        Public Property time_spent_on_fire_most_in_game As Single
        Public Property multikill_best As Single
        Public Property environmental_kills As Single
        Public Property objective_kills As Single
        Public Property objective_time As Single
        Public Property objective_time_most_in_game As Single
        Public Property time_played As Single
        Public Property final_blows_most_in_game As Single
        Public Property shots_fired As Single
        Public Property turrets_destroyed As Single
        Public Property kill_streak_best As Single
        Public Property final_blows As Single
        Public Property solo_kills As Single
        Public Property shots_hit As Single
        Public Property time_spent_on_fire As Single
        Public Property environmental_deaths As Single
        Public Property medals_gold As Single
        Public Property eliminations_most_in_life As Single
        Public Property damage_done_most_in_life As Single
        Public Property damage_done As Single
        Public Property objective_kills_most_in_game As Single
        Public Property cards As Single
        Public Property shield_generators_destroyed As Single
        Public Property teleporter_pads_destroyed As Single
        Public Property solo_kills_most_in_game As Single
        Public Property medals As Single
        Public Property games_won As Single
        Public Property eliminations_per_life As Single
        Public Property melee_final_blow As Single
        Public Property medals_bronze As Single
        Public Property weapon_accuracy_best_in_game As Single
        Public Property medals_silver As Single
        Public Property damage_done_most_in_game As Single
        Public Property eliminations_most_in_game As Single
        Public Property deaths As Single
    End Class

    Public Class Torbjorn
        Public Property average_stats As Average_Stats34
        Public Property hero_stats As Hero_Stats32
        Public Property general_stats As General_Stats32
    End Class

    Public Class Average_Stats34
        Public Property turret_kills_average As Single
        Public Property critical_hits_average As Single
        Public Property eliminations_average As Single
        Public Property torbjorn_kills_average As Single
        Public Property objective_time_average As Single
        Public Property damage_done_average As Single
        Public Property objective_kills_average As Single
        Public Property melee_final_blows_average As Single
        Public Property time_spent_on_fire_average As Single
        Public Property solo_kills_average As Single
        Public Property molten_core_kills_average As Single
        Public Property final_blows_average As Single
        Public Property armor_packs_created_average As Single
        Public Property deaths_average As Single
    End Class

    Public Class Hero_Stats32
        Public Property armor_packs_created As Single
        Public Property turret_kills As Single
        Public Property torbjorn_kills As Single
        Public Property torbjorn_kills_most_in_game As Single
        Public Property molten_core_kills_most_in_game As Single
        Public Property melee_final_blow_most_in_game As Single
        Public Property molten_core_kills As Single
    End Class

    Public Class General_Stats32
        Public Property multikills As Single
        Public Property weapon_accuracy As Single
        Public Property eliminations As Single
        Public Property multikill_best As Single
        Public Property shots_fired As Single
        Public Property cards As Single
        Public Property objective_kills As Single
        Public Property objective_time As Single
        Public Property objective_time_most_in_game As Single
        Public Property time_played As Single
        Public Property final_blows_most_in_game As Single
        Public Property eliminations_per_life As Single
        Public Property turrets_destroyed As Single
        Public Property kill_streak_best As Single
        Public Property final_blows As Single
        Public Property solo_kills As Single
        Public Property shots_hit As Single
        Public Property time_spent_on_fire As Single
        Public Property environmental_deaths As Single
        Public Property medals_gold As Single
        Public Property eliminations_most_in_life As Single
        Public Property damage_done_most_in_life As Single
        Public Property damage_done As Single
        Public Property objective_kills_most_in_game As Single
        Public Property critical_hit_accuracy As Single
        Public Property melee_final_blows As Single
        Public Property solo_kills_most_in_game As Single
        Public Property medals As Single
        Public Property games_won As Single
        Public Property critical_hits As Single
        Public Property critical_hits_most_in_game As Single
        Public Property medals_bronze As Single
        Public Property weapon_accuracy_best_in_game As Single
        Public Property medals_silver As Single
        Public Property damage_done_most_in_game As Single
        Public Property eliminations_most_in_game As Single
        Public Property critical_hits_most_in_life As Single
        Public Property deaths As Single
    End Class

    Public Class Playtime
        Public Property competitive As Competitive2
        Public Property quickplay As Quickplay2
    End Class

    Public Class Competitive2
        Public Property widowmaker As Integer
        Public Property ana As Single
        Public Property winston As Single
        Public Property mei As Integer
        Public Property tracer As Integer
        Public Property sombra As Integer
        Public Property symmetra As Integer
        Public Property hanzo As Integer
        Public Property lucio As Single
        Public Property mercy As Integer
        Public Property orisa As Integer
        Public Property mccree As Integer
        Public Property reaper As Integer
        Public Property genji As Integer
        Public Property zenyatta As Integer
        Public Property bastion As Integer
        Public Property zarya As Single
        Public Property roadhog As Single
        Public Property reinhardt As Single
        Public Property soldier76 As Single
        Public Property dva As Integer
        Public Property junkrat As Single
        Public Property pharah As Single
        Public Property torbjorn As Integer
    End Class

    Public Class Quickplay2
        Public Property widowmaker As Single
        Public Property hanzo As Single
        Public Property winston As Single
        Public Property mei As Single
        Public Property tracer As Single
        Public Property sombra As Single
        Public Property symmetra As Single
        Public Property ana As Single
        Public Property lucio As Single
        Public Property mercy As Single
        Public Property orisa As Single
        Public Property mccree As Single
        Public Property reaper As Single
        Public Property genji As Single
        Public Property zenyatta As Single
        Public Property bastion As Single
        Public Property zarya As Single
        Public Property roadhog As Single
        Public Property reinhardt As Single
        Public Property soldier76 As Single
        Public Property dva As Single
        Public Property junkrat As Single
        Public Property pharah As Single
        Public Property torbjorn As Single
    End Class

    Public Class _Request
        Public Property route As String
        Public Property api_ver As Integer
    End Class
End Class
Public Class config

    Public Class config
        Public Property token As String
        Public Property googleConfig As Googleconfig
    End Class

    Public Class Googleconfig
        Public Property apikey As String
        Public Property cx As String
    End Class

End Class
Public Class qdb
    
End Class