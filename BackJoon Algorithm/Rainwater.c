//https://www.acmicpc.net/problem/14719
//Rainwater Problem

//CONDITION
//- Cannot use loop statement
//- Must use goto statement
//- Based on C language

//Could not find exception in the code.
//Need feedback later.

#include <stdio.h>
#include <stdlib.h>

int main() {

	//Input Width, Height
	int Result = 0;
	int Height = 0;
	int Width = 0;

	scanf("%d %d", &Height, &Width);

	int* BlocksHeight = malloc(sizeof(int) * Width);

	//Input BlocksHeight

	int RepeatIndex = 0;

Repeat_Input_BlocksHeight:
	if (RepeatIndex < Width) {

		BlocksHeight[RepeatIndex] = 0;
		scanf("%d", &BlocksHeight[RepeatIndex]);

		RepeatIndex++;
		goto Repeat_Input_BlocksHeight;
	}

	//Find Result

	//Do From Left
	int BlockIndex = 0;
	RepeatIndex = 1;

Do_From_Left:

	if (BlockIndex >= Width) goto Exit_Do_Left;

Repeat_Find_WrapBlock_Left:
	if (RepeatIndex <= Width) {
		if (BlocksHeight[BlockIndex] <= BlocksHeight[RepeatIndex]) {

			int Count = BlockIndex + 1;

		Repeat_Add_WaterHeight_Left:
			if (Count < RepeatIndex) {
				Result += (BlocksHeight[BlockIndex] - BlocksHeight[Count]);
				Count++;
				goto Repeat_Add_WaterHeight_Left;
			}
		}
		else {
			RepeatIndex++;
			goto Repeat_Find_WrapBlock_Left;
		}
	}

	BlockIndex = RepeatIndex;
	RepeatIndex = BlockIndex + 1;
	goto Do_From_Left;

Exit_Do_Left:

	//Do From Right
	BlockIndex = Width - 1;
	RepeatIndex = BlockIndex - 1;

Do_From_Right:

	if (BlockIndex < 0) goto Exit_Do_Right;

Repeat_Find_WrapBlock_Right:
	if (RepeatIndex >= 0) {
		if (BlocksHeight[BlockIndex] < BlocksHeight[RepeatIndex]) {

			int Count = BlockIndex - 1;

		Repeat_Add_WaterHeight_Right:
			if (Count > RepeatIndex) {
				Result += (BlocksHeight[BlockIndex] - BlocksHeight[Count]);
				Count--;
				goto Repeat_Add_WaterHeight_Right;
			}
		}
		else {
			RepeatIndex--;
			goto Repeat_Find_WrapBlock_Right;
		}
	}

	BlockIndex = RepeatIndex;
	RepeatIndex = BlockIndex - 1;
	goto Do_From_Right;

Exit_Do_Right:

	printf("%d", Result);
}