	@i
	M=0
	@R2
	M=0
(LOOP)
	@i
	D=M  //put times-added count in D
	@R1
	D=D-M // subtract times-added count from times to be added
	@END
	D;JEQ // if times-adding count equals times to be added, go to END
	@R2
	D=M
	@R0
	D=D+M
	@R2
	M=D
	@i
	M=M+1
	@LOOP
	0;JMP
(END)
	@END
	0;JMP

