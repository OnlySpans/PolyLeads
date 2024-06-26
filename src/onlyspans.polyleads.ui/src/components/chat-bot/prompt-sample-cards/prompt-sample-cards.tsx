import { FC } from 'react';
import {
  Carousel,
  CarouselContent,
  CarouselItem,
  CarouselNext,
  CarouselPrevious,
} from '@/components/ui/carousel';
import { Card, CardContent, CardHeader, CardTitle } from '@/components/ui/card';
import { promptSamplesData } from '@/components/chat-bot/prompt-sample-cards/prompt-samples.data';
import Autoplay from 'embla-carousel-autoplay';
import useGet from '@/hooks/useGet';
import { IPromptInputVM } from '@/components/chat-bot/prompt-input/prompt-input.vm';
import ServiceSymbols from '@/data/constant/ServiceSymbols';

const PromptSampleCards: FC = () => {
  const vm = useGet<IPromptInputVM>(ServiceSymbols.IPromptInputVM);

  return (
    <Carousel
      opts={{
        align: 'start',
      }}
      plugins={[
        Autoplay({
          delay: 2000,
        }),
      ]}
      className='lg:w-[75%] sm:w-[70%] w-[50%]'
    >
      <CarouselContent>
        {promptSamplesData.map((sample, index) => (
          <CarouselItem key={index} className='sm:basis-1/2 lg:basis-1/3'>
            <div className='p-1'>
              <Card
                className='bg-muted hover:bg-muted-foreground/25 cursor-pointer max-h-[30%]'
                onClick={() => vm.sendSamplePrompt(sample.prompt)}
              >
                <CardHeader className='pb-2'>
                  <CardTitle>{sample.icon}</CardTitle>
                </CardHeader>
                <CardContent className='flex min-h-32 items-start justify-center p-4'>
                  {sample.prompt}
                </CardContent>
              </Card>
            </div>
          </CarouselItem>
        ))}
      </CarouselContent>
      <CarouselPrevious />
      <CarouselNext />
    </Carousel>
  );
};

export default PromptSampleCards;