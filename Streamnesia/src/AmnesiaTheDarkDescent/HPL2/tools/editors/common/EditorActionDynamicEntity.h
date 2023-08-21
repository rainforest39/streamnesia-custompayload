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

#ifndef HPLEDITOR_EDITOR_ACTION_AREA_H
#define HPLEDITOR_EDITOR_ACTION_AREA_H


#include "../common/StdAfx.h"
using namespace hpl;

#include "EditorAction.h"
#include "EditorTypes.h"

//--------------------------------------------------------------------

class iEditorWorld;

//--------------------------------------------------------------------

////////////////////////////////////////////////////////////
// ENTITY SET FILE
////////////////////////////////////////////////////////////

//--------------------------------------------------------------------

class cEditorActionEntitySetFilename : public iEditorActionWorldModifier
{
public:
	cEditorActionEntitySetFilename(iEditorWorld* apWorld, int alID, const tString& asX);

	void DoModify();
	void UndoModify();

protected:
	void Apply(const tString& asX);

	int mlID;
	tVarValueMap mmapOldValues;
	tString msOldFile;
	tString msNewFile;
};


//--------------------------------------------------------------------

#endif // HPLEDITOR_EDITOR_ACTION_AREA_H
