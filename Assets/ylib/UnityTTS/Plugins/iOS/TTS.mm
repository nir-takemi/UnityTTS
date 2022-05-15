#import <AVFoundation/AVFoundation.h>
#import <QuartzCore/QuartzCore.h>

extern "C" void _speechText (const char *text, float volume, float rate, float pitch, const char *language)
{
    NSString *encText = [NSString stringWithCString:text encoding:NSUTF8StringEncoding];
    NSString *encLanguage = [NSString stringWithCString:language encoding:NSUTF8StringEncoding];
    
    AVSpeechSynthesizer *synthesizer = [[AVSpeechSynthesizer alloc]init];

    AVSpeechUtterance *speechutt = [AVSpeechUtterance speechUtteranceWithString:encText];
    speechutt.volume=volume;
    speechutt.rate=rate;
    speechutt.pitchMultiplier=pitch;
    speechutt.voice = [AVSpeechSynthesisVoice voiceWithLanguage:encLanguage];
    [synthesizer speakUtterance:speechutt];
}
