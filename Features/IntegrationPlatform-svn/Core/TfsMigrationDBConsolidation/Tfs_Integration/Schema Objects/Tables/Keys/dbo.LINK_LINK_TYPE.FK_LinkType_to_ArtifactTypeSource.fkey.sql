﻿ALTER TABLE [dbo].[LINK_LINK_TYPE]
	ADD CONSTRAINT [FK_LinkType_to_ArtifactTypeSource] 
	FOREIGN KEY (SourceArtifactTypeId)
	REFERENCES LINK_ARTIFACT_TYPE (Id)	

