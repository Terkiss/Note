









/// NotiMessage 테이블 CREATE
CREATE TABLE `language` (
	`id` INT(11) NOT NULL,
	`KOR` VARCHAR(100) NOT NULL COLLATE 'utf8mb4_general_ci',
	`ENG` VARCHAR(100) NOT NULL COLLATE 'utf8mb4_general_ci',
	`GER` VARCHAR(100) NOT NULL COLLATE 'utf8mb4_general_ci',
	`FRA` VARCHAR(100) NOT NULL COLLATE 'utf8mb4_general_ci',
	`IND` VARCHAR(100) NOT NULL COLLATE 'utf8mb4_general_ci',
	`THA` VARCHAR(100) NOT NULL COLLATE 'utf8mb4_general_ci',
	`CHIS` VARCHAR(100) NOT NULL COLLATE 'utf8mb4_general_ci',
	`ARAB` VARCHAR(100) NOT NULL COLLATE 'utf8mb4_general_ci',
	`HIN` VARCHAR(100) NOT NULL COLLATE 'utf8mb4_general_ci',
	`SPA` VARCHAR(100) NOT NULL COLLATE 'utf8mb4_general_ci',
	`RUS` VARCHAR(100) NOT NULL COLLATE 'utf8mb4_general_ci',
	`JAP` VARCHAR(100) NOT NULL COLLATE 'utf8mb4_general_ci',
	PRIMARY KEY (`id`) USING BTREE
)
COLLATE='utf8mb4_general_ci'
ENGINE=InnoDB
;
