CONFIGURATION     = Debug
JNIENV_GEN        = ../../bin/BuildDebug/jnienv-gen.exe

all: test-overheads.exe libjava-interop.dylib

clean:
	-rm test-overheads.exe test-overheads.exe.mdb
	-rm -Rf libJavaInterop.dylib*

include ../../build-tools/scripts/mono.mk
include ../../build-tools/scripts/jdk.mk
include ../../bin/BuildDebug/JdkInfo.mk
include ../../build-tools/scripts/msbuild.mk

$(JNIENV_GEN):
	(cd ../../build-tools/jnienv-gen ; $(MSBUILD) $(MSBUILD_FLAGS) )

HANDLE_FEATURES = \
	-d:FEATURE_JNIENVIRONMENT_JI_INTPTRS \
	-d:FEATURE_JNIENVIRONMENT_JI_PINVOKES \
	-d:FEATURE_JNIENVIRONMENT_SAFEHANDLES \
	-d:FEATURE_JNIENVIRONMENT_XA_INTPTRS

test-overheads.exe: test-overheads.cs jni.cs
	mcs -out:$@ -unsafe $(HANDLE_FEATURES) $^

jni.c jni.cs: $(JNIENV_GEN)
	$(RUNTIME) $< jni.cs jni.c

libjava-interop.dylib: jni.c
	gcc -g -shared -fPIC -o $@ $< -m64 -DJI_DLL_EXPORT -fvisibility=hidden $(JI_JDK_INCLUDE_PATHS:%=-I%)

run:
	$(RUNTIME) test-overheads.exe
