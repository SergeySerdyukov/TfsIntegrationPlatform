﻿ALTER TABLE [dbo].[LINK_LINK_CHANGE_ACTIONS]
	ADD CONSTRAINT [FK_LinkChangeAction_to_ArtifactLink] 
	FOREIGN KEY (ArtifactLinkId)
	REFERENCES LINK_ARTIFACT_LINK (Id)	
