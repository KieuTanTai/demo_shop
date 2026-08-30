CREATE TABLE `account`
(
    `account_id`           uuid PRIMARY KEY DEFAULT (uuid_v7()),
    `account_email`        varchar(255) UNIQUE NOT NULL,
    `account_password`     varchar(50)         NOT NULL,
    `account_login_status` boolean          DEFAULT false,
    `account_created_at`   timestamp        DEFAULT (now()),
    `account_updated_at`   timestamp        DEFAULT (now())
);

CREATE TABLE `role`
(
    `role_id`          uuid PRIMARY KEY             DEFAULT (uuid_v7()),
    `role_name`        varchar(100) UNIQUE NOT NULL,
    `role_description` tinytext            NOT NULL DEFAULT '',
    `role_active`      boolean                      DEFAULT true,
    `role_created_at`  timestamp                    DEFAULT (now()),
    `role_updated_at`  timestamp                    DEFAULT (now())
);

CREATE TABLE `permission`
(
    `permission_id`          uuid PRIMARY KEY             DEFAULT (uuid_v7()),
    `permission_name`        varchar(150) UNIQUE NOT NULL,
    `permission_description` tinytext            NOT NULL DEFAULT '',
    `permission_active`      boolean                      DEFAULT true,
    `permission_created_at`  timestamp                    DEFAULT (now()),
    `permission_updated_at`  timestamp                    DEFAULT (now())
);

CREATE TABLE `account_role`
(
    `account_id`  uuid,
    `role_id`     uuid,
    `assigned_at` timestamp DEFAULT (now()),
    PRIMARY KEY (`account_id`, `role_id`)
);

CREATE TABLE `role_permission`
(
    `role_id`       uuid,
    `permission_id` uuid,
    `assigned_at`   timestamp DEFAULT (now()),
    PRIMARY KEY (`role_id`, `permission_id`)
);

CREATE TABLE `account_permission`
(
    `account_id`    uuid,
    `permission_id` uuid,
    `assigned_at`   timestamp DEFAULT (now()),
    PRIMARY KEY (`account_id`, `permission_id`)
);

ALTER TABLE `account`
    MODIFY COLUMN `account_password`
        VARCHAR(255)
        NOT NULL;

ALTER TABLE `account`
    DROP COLUMN `account_login_status`,
    ADD COLUMN `account_is_active` BOOLEAN NOT NULL DEFAULT TRUE;

ALTER TABLE `account`
    ADD COLUMN `account_phone_number` VARCHAR(10);

ALTER TABLE `role`
    MODIFY COLUMN `role_description` VARCHAR(300);

ALTER TABLE `permission`
    MODIFY COLUMN `permission_description` VARCHAR(300);

ALTER TABLE `role`
    CHANGE COLUMN `role_active`
        `role_is_active` BOOLEAN NOT NULL DEFAULT TRUE;

ALTER TABLE `role`
    MODIFY COLUMN `role_name` VARCHAR(150) UNIQUE NOT NULL;

ALTER TABLE `permission`
    CHANGE COLUMN `permission_active`
        `permission_is_active` BOOLEAN NOT NULL DEFAULT TRUE;

ALTER TABLE `account_role`
    ADD FOREIGN KEY (`account_id`) REFERENCES `account` (`account_id`);

ALTER TABLE `account_role`
    ADD FOREIGN KEY (`role_id`) REFERENCES `role` (`role_id`);

ALTER TABLE `role_permission`
    ADD FOREIGN KEY (`role_id`) REFERENCES `role` (`role_id`);

ALTER TABLE `role_permission`
    ADD FOREIGN KEY (`permission_id`) REFERENCES `permission` (`permission_id`);

ALTER TABLE `account_permission`
    ADD FOREIGN KEY (`account_id`) REFERENCES `account` (`account_id`);

ALTER TABLE `account_permission`
    ADD FOREIGN KEY (`permission_id`) REFERENCES `permission` (`permission_id`);

ALTER TABLE `account`
    ADD UNIQUE INDEX `idx_account_email` (`account_email`),
    ADD INDEX `idx_account_phone_number` (`account_phone_number`);

ALTER TABLE `role`
    ADD UNIQUE INDEX `idx_role_name` (`role_name`);

ALTER TABLE `permission`
    ADD UNIQUE INDEX `idx_permission_name` (`permission_name`);

RENAME TABLE `account_permission`
    TO `account_additional_permission`;

ALTER TABLE `role`
    ADD COLUMN `role_code` VARCHAR(50) NOT NULL AFTER `role_id`;

ALTER TABLE `role`
    ADD UNIQUE INDEX `idx_role_code` (`role_code`);

ALTER TABLE `permission`
    ADD COLUMN `permission_code` VARCHAR(50) NOT NULL AFTER `permission_id`;

ALTER TABLE `permission`
    ADD UNIQUE INDEX `idx_permission_code` (`permission_code`);


SHOW COLUMNS FROM account;
SHOW COLUMNS FROM role;
SHOW COLUMNS FROM permission;
SHOW COLUMNS FROM account_additional_permission;

SHOW VARIABLES LIKE 'character_set_server';
SHOW VARIABLES LIKE 'collation_server';

# TRIGGER
DELIMITER //
CREATE TRIGGER `trigger_permission_code_immutable`
    BEFORE UPDATE
    ON `permission`
    FOR EACH ROW
BEGIN
    IF NOT (OLD.`permission_code` <=> NEW.`permission_code`)
    THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Permission code cannot be changed';
    END IF;
END //

CREATE TRIGGER `trigger_role_code_immutable`
    BEFORE UPDATE
    ON `role`
    FOR EACH ROW
BEGIN
    IF NOT (OLD.`role_code` <=> NEW.`role_code`)
    THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Role code cannot be changed';
    END IF;
END //

DELIMITER ;

SHOW TRIGGERS;
