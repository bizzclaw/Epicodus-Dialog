-- ---
-- Globals
-- ---

-- SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
-- SET FOREIGN_KEY_CHECKS=0;

-- ---
-- Table 'posts'
--
-- ---
DROP DATABASE IF EXISTS dialog_test;
CREATE DATABASE dialog_test;
USE dialog_test;


DROP TABLE IF EXISTS `posts`;

CREATE TABLE `posts` (
  `id` INTEGER NULL AUTO_INCREMENT DEFAULT NULL,
  `thread_id` INTEGER NULL DEFAULT NULL,
  `subject` VARCHAR(255) DEFAULT 'Reply',
  `message` TEXT NULL DEFAULT NULL,
  `date` DATETIME NULL DEFAULT NULL,
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
  `topic_id` INTEGER NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
);

-- ---
-- Table 'topics'
--
-- ---

DROP TABLE IF EXISTS `topics`;

CREATE TABLE `topics` (
  `id` INTEGER NULL AUTO_INCREMENT DEFAULT NULL,
  `name` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
);

-- ---
-- Foreign Keys
-- ---

-- ALTER TABLE `posts` ADD FOREIGN KEY (thread_id) REFERENCES `threads` (`id`);
-- ALTER TABLE `threads` ADD FOREIGN KEY (topics_id) REFERENCES `topics` (`id`);

-- ---
-- Table Properties
-- ---

-- ALTER TABLE `posts` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `threads` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `topics` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- ---
-- Test Data
-- ---

-- INSERT INTO `posts` (`id`,`thread_id`,`subject`,`message`,`author`,`avatar`) VALUES
-- ('','','','','','');
-- INSERT INTO `threads` (`id`,`topics_id`) VALUES
-- ('','');
-- INSERT INTO `topics` (`id`,`topic`) VALUES
-- ('','');
