USE [Blog]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.Tag_dbo.Post_Post_Id]') AND parent_object_id = OBJECT_ID(N'[dbo].[Tag]'))
ALTER TABLE [dbo].[Tag] DROP CONSTRAINT [FK_dbo.Tag_dbo.Post_Post_Id]
GO
