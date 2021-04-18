#version 330 core


layout(location = 0) in vec3 aPosition;

uniform mat4 transform;
out vec3 aPos;
void main(void){
	aPos.xyz = aPosition.xyz;
	gl_Position = vec4(aPosition,1.0) * transform;

}