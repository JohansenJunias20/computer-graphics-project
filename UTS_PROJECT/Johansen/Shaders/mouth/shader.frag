#version 330 core

out vec4 outputColor;
in vec3 aPos;
void main(){
	if(aPos.y >= -0.026){
		outputColor = vec4(0.57,0.07,0.8,1.0);
	}
	
	if(aPos.y <= -0.026){
		outputColor = vec4(0.72,0.09,1.0,1.0);
	}

}