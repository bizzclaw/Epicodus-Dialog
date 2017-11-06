-- ---
-- Globals
-- ---

-- SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
-- SET FOREIGN_KEY_CHECKS=0;

-- ---
-- Table 'posts'
--
-- ---
DROP DATABASE IF EXISTS dialog;
CREATE DATABASE dialog;
USE dialog;


DROP TABLE IF EXISTS `posts`;

CREATE TABLE `posts` (
  `id` INTEGER NULL AUTO_INCREMENT DEFAULT NULL,
  `thread_id` INTEGER NULL DEFAULT NULL,
  `subject` VARCHAR(255) DEFAULT 'Reply',
  `message` TEXT NULL DEFAULT NULL,
  `author` VARCHAR(40) NULL DEFAULT 'Anonymous',
  `avatar` TEXT NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
);

-- ---
-- Table 'threads'
--
-- ---

DROP TABLE IF EXISTS `threads`;

CREATE TABLE `threads` (
  `id` INTEGER NULL AUTO_INCREMENT DEFAULT NULL,
  `groups_id` INTEGER NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
);

-- ---
-- Table 'groups'
--
-- ---

DROP TABLE IF EXISTS `groups`;

CREATE TABLE `groups` (
  `id` INTEGER NULL AUTO_INCREMENT DEFAULT NULL,
  `topic` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
);

-- ---
-- Foreign Keys
-- ---

-- ALTER TABLE `posts` ADD FOREIGN KEY (thread_id) REFERENCES `threads` (`id`);
-- ALTER TABLE `threads` ADD FOREIGN KEY (groups_id) REFERENCES `groups` (`id`);

-- ---
-- Table Properties
-- ---

-- ALTER TABLE `posts` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `threads` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `groups` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- ---
-- Test Data
-- ---

-- INSERT INTO `posts` (`id`,`thread_id`,`subject`,`message`,`author`,`avatar`) VALUES
-- ('','','','','','');
-- INSERT INTO `threads` (`id`,`groups_id`) VALUES
-- ('','');
-- INSERT INTO `groups` (`id`,`topic`) VALUES
-- ('','');
