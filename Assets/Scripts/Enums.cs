﻿using UnityEngine;
using System.Collections;

public enum buttonResponse
{
    LOAD_MINIGAME_A,
    LOAD_MINIGAME_B,
    LOAD_MINIGAME_C,
    LOAD_AWARDS_SCENE,
    RETURN_TO_MAIN,
    QUITAPP,
    CODED_MANUALLY,
    NOT_A_BUTTON
}

public enum cardColour
{
    RED,
    GREEN,
    BLUE,
    CYAN,
    YELLOW,
    MAGENTA,
    WHITE,
    BLACK,
	GREY,
    MAX
}

public enum clickState
{
	DEFAULT,
	FIRST_CLICK,
	SECOND_CLICK,
	MAX
}
