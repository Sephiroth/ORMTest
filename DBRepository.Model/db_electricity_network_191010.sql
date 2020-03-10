/*
 Navicat Premium Data Transfer

 Source Server         : 192.168.0.82
 Source Server Type    : MySQL
 Source Server Version : 80011
 Source Host           : 192.168.0.82:3306
 Source Schema         : db_electricity_network

 Target Server Type    : MySQL
 Target Server Version : 80011
 File Encoding         : 65001

 Date: 10/10/2019 17:35:24
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for t_log
-- ----------------------------
DROP TABLE IF EXISTS `t_log`;
CREATE TABLE `t_log`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `module` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '模块',
  `log` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '日志内容',
  `operator_idcard` varchar(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '操作员身份证号',
  `operator_role` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '操作员角色',
  `operator_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '操作员姓名',
  `create_time` datetime(0) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for t_power
-- ----------------------------
DROP TABLE IF EXISTS `t_power`;
CREATE TABLE `t_power`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `power_name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '权限名',
  `power_interface` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '权限接口',
  `create_time` datetime(0) NULL DEFAULT NULL,
  `update_time` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci COMMENT = '权限表: 权限名称 + 接口名称' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of t_power
-- ----------------------------
INSERT INTO `t_power` VALUES (1, '用户接口', '/user/adduser', NULL, NULL);

-- ----------------------------
-- Table structure for t_role_power
-- ----------------------------
DROP TABLE IF EXISTS `t_role_power`;
CREATE TABLE `t_role_power`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `role_id` int(11) NOT NULL COMMENT '角色id',
  `power_id` int(11) NOT NULL COMMENT '权限id',
  `create_time` datetime(0) NULL DEFAULT NULL,
  `update_time` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci COMMENT = '关联角色和权限的表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of t_role_power
-- ----------------------------
INSERT INTO `t_role_power` VALUES (1, 1, 1, NULL, NULL);

-- ----------------------------
-- Table structure for t_roleinfo
-- ----------------------------
DROP TABLE IF EXISTS `t_roleinfo`;
CREATE TABLE `t_roleinfo`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `role_name_en` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '英文角色名',
  `role_name_cn` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '中文角色名',
  `create_time` datetime(0) NULL DEFAULT NULL,
  `update_time` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci COMMENT = '用户角色信息表' ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of t_roleinfo
-- ----------------------------
INSERT INTO `t_roleinfo` VALUES (1, 'admin', '管理员', NULL, NULL);

-- ----------------------------
-- Table structure for t_user_role
-- ----------------------------
DROP TABLE IF EXISTS `t_user_role`;
CREATE TABLE `t_user_role`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_idcard` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '用户身份证号',
  `role_id` int(11) NOT NULL COMMENT '角色id',
  `create_time` datetime(0) NULL DEFAULT NULL,
  `update_time` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `fk_user_idcard`(`user_idcard`) USING BTREE,
  INDEX `role_id`(`role_id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of t_user_role
-- ----------------------------
INSERT INTO `t_user_role` VALUES (1, '340123199911112222', 1, NULL, NULL);

-- ----------------------------
-- Table structure for t_userinfo
-- ----------------------------
DROP TABLE IF EXISTS `t_userinfo`;
CREATE TABLE `t_userinfo`  (
  `id` int(32) NOT NULL AUTO_INCREMENT COMMENT '自增主键ID',
  `idcard` char(18) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '最长18个字符',
  `phone` varchar(13) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `username` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT '',
  `password` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT '',
  `sex` enum('男','女') CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT '男' COMMENT '枚举:男\\女',
  `email` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `create_time` datetime(0) NULL DEFAULT NULL,
  `update_time` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  UNIQUE INDEX `uk_idcard`(`idcard`) USING BTREE COMMENT '身份证号唯一'
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of t_userinfo
-- ----------------------------
INSERT INTO `t_userinfo` VALUES (1, '340123199911112222', '12312341234', 'lutao', '123', '男', 'qq.com', NULL, NULL);
INSERT INTO `t_userinfo` VALUES (2, '123123123412341234', '18811112222', 'asd', '123', '女', '123qq.com', NULL, NULL);

-- ----------------------------
-- View structure for v_role_power
-- ----------------------------
DROP VIEW IF EXISTS `v_role_power`;
CREATE ALGORITHM = UNDEFINED DEFINER = `root`@`%` SQL SECURITY DEFINER VIEW `v_role_power` AS select `t`.`id` AS `id`,`t`.`role_id` AS `role_id`,`r`.`role_name_en` AS `role_name_en`,`r`.`role_name_cn` AS `role_name_cn`,`t`.`power_id` AS `power_id`,`p`.`power_interface` AS `power_interface`,`p`.`power_name` AS `power_name` from ((`t_role_power` `t` left join `t_roleinfo` `r` on((`t`.`role_id` = `r`.`id`))) left join `t_power` `p` on((`t`.`power_id` = `p`.`id`)));

-- ----------------------------
-- View structure for v_user_role
-- ----------------------------
DROP VIEW IF EXISTS `v_user_role`;
CREATE ALGORITHM = UNDEFINED DEFINER = `root`@`%` SQL SECURITY DEFINER VIEW `v_user_role` AS select `u`.`id` AS `id`,`u`.`idcard` AS `idcard`,`u`.`phone` AS `phone`,`u`.`username` AS `username`,`u`.`password` AS `password`,`u`.`sex` AS `sex`,`u`.`email` AS `email`,`t`.`role_id` AS `role_id`,`r`.`role_name_en` AS `role_name_en`,`r`.`role_name_cn` AS `role_name_cn` from ((`t_user_role` `t` left join `t_userinfo` `u` on((`t`.`user_idcard` = `u`.`idcard`))) left join `t_roleinfo` `r` on((`t`.`role_id` = `r`.`id`)));

SET FOREIGN_KEY_CHECKS = 1;
