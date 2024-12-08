#ifndef WRAPPER_H
#define WRAPPER_H

#ifdef _WIN32

typedef const wchar_t *AutoString;

#else

typedef const char *AutoString;

#endif

#endif // !WRAPPER_H

struct FaceDetected
{
	int x, y;
	int width, height;
	float confidence;

	int p1x;
	int p1y;
	int p2x;
	int p2y;
	int p3x;
	int p3y;
	int p4x;
	int p4y;
	int p5x;
	int p5y;
};

typedef int (*DetectCallback)(const FaceDetected *faceDetected);

class Wrapper
{
public:
	Wrapper();
	~Wrapper();
	int Detect(unsigned char *data, bool rgb2bgr, int width, int height, int step, DetectCallback callback);

private:
	unsigned char *pBuffer;
};