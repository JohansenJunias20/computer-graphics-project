#version 330 core

in vec3 oPos;
out vec4 outputColor;

void main(){
		outputColor = vec4(0.5 - oPos.y*2, 0.0, 0.5 -oPos.y*2,1.0);



}