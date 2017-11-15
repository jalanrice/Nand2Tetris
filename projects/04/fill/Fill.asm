// This file is part of www.nand2tetris.org
// and the book "The Elements of Computing Systems"
// by Nisan and Schocken, MIT Press.
// File name: projects/04/Fill.asm

// Runs an infinite loop that listens to the keyboard input.
// When a key is pressed (any key), the program blackens the screen,
// i.e. writes "black" in every pixel;
// the screen should remain fully black as long as the key is pressed. 
// When no key is pressed, the program clears the screen, i.e. writes
// "white" in every pixel;
// the screen should remain fully clear as long as no key is pressed.



//	if (SCREEN > 0)
//	{
//		for (i=0; i<lr; i++;)
//		{
//			draw 16 black pixels at screen (word = -1);
//			screen = screen + 1;
//		}
//	}
//	
//	if (SCREEN == 0)
//	{
//		for (i=0; i<lr; i++;)
//		{
//			draw 16 white pixels at screen;
//			SCREEN = SCREEN +1;
//		}
//	}
//	n = 131072
//	i = 0
//	addr = SCREEN
//	
//	LOOP:
//		if i > n goto END
//		RAM[addr] = -1
//		addr = addr +1
//		i = i + 1
//		goto LOOP
//		
//	END:
//		goto END
		

// Put your code here.
@SCREEN
D=A
@addr
M=D // addr = 16384
@0
D=M
@n
M=D

@i
M=0

// test
(TEST)
@KBD
D=M
@BLACK
D;JGT
@WHITE
D;JEQ
@TEST
0;JMP

(BLACK)
@i
D=M
@n
D=D-M

@addr
A=M
M=-1

@i
M=M+1
@1
D=A
@addr
M=D+M //addr = addr + 1

// test
@KBD
D=M
@BLACK
D;JGT


(WHITE)
@i
D=M
@n
D=D-M


@addr
A=M
M=0

@i
M=M+1
@1
D=A
@addr
M=D+M //addr = addr + 1
@WHITE
0;JMP //goto WHITE


(END)
@END
0;JMP



