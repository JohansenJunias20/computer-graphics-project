#version 330 core


layout(location = 0) in vec3 aPosition;
out vec3 oPos;
uniform mat4 transform;

void main(void){
	oPos.xyz = aPosition.xyz;
	gl_Position = vec4(aPosition,1.0) * transform;

}