/*
 * Copyright © 2009-2020 Frictional Games
 * 
 * This file is part of Amnesia: The Dark Descent.
 * 
 * Amnesia: The Dark Descent is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version. 

 * Amnesia: The Dark Descent is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with Amnesia: The Dark Descent.  If not, see <https://www.gnu.org/licenses/>.
 */

#ifndef MATERIAL_EDITOR_H
#define MATERIAL_EDITOR_H

//---------------------------------------------------------

#include "../Common/Editor.h"

class cEdWindowMaterialEditor;

//---------------------------------------------------------

class cMaterialEditor : public iEditor
{
public:
	cMaterialEditor(const tWString& asCommandLine);
	~cMaterialEditor();

protected:
	void Update(float afTimeStep);

	void SetUpDirectories();
	void SetUpEditModes();

	iEdMenu*	CreateMenu();
    iEdWorld*	CreateWorld();

	void CreateAppSpecificLayout();

	cEdWindowMaterialEditor* mpMainWindow;

	tWString msCommandLineFile;
};

//---------------------------------------------------------

#endif // MATERIAL_EDITOR_H
