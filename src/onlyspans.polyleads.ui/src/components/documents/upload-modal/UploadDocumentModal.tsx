import React from 'react';
import { observer } from 'mobx-react-lite';
import {
  Dialog,
  DialogClose,
  DialogContent,
  DialogDescription,
  DialogFooter,
  DialogHeader,
  DialogTitle,
  DialogTrigger
} from '@/components/ui/dialog';
import { Button } from '@/components/ui/button';
import { Label } from '@/components/ui/label';
import { Input } from '@/components/ui/input';
import useGet from '@/hooks/useGet';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import { useForm } from 'react-hook-form';
import { z } from 'zod';
import { zodResolver } from '@hookform/resolvers/zod';
import { Form, FormControl, FormField, FormItem, FormMessage } from '@/components/ui/form';
import { IUploadDocumentModalVM } from './UploadDocumentModal.vm';
import { Upload } from 'lucide-react';

const UploadDocumentModal: React.FC = () => {
  const vm = useGet<IUploadDocumentModalVM>(
    ServiceSymbols.IUploadDocumentModalVM);

  const form = useForm<z.infer<typeof vm.uploadFormSchema>>({
    resolver: zodResolver(vm.uploadFormSchema)
  });

  return (
    <Dialog open={vm.isOpened} onOpenChange={vm.setIsOpened}>
      <DialogTrigger asChild>
        <Button variant='default' className='h-8 px-4'>
          <Upload className={'sm:hidden flex size-4'} />
          <div className={'hidden sm:flex'}>Добавить файл</div>
        </Button>
      </DialogTrigger>
      <DialogContent className="sm:max-w-[425px] max-w-[90%] gap-6">
        <DialogHeader>
          <DialogTitle>Добавить файл</DialogTitle>
          <DialogDescription>
            Распознавание файла займет некоторое время
          </DialogDescription>
        </DialogHeader>
        <Form {...form}>
          <form onSubmit={form.handleSubmit(vm.upload)}>
            <div className="grid w-full items-center gap-6">
              <FormField
                control={form.control}
                name="documentName"
                render={({ field }) => (
                  <FormItem className="flex flex-col space-y-3">
                    <Label htmlFor="documentName">Название документа</Label>
                    <FormControl>
                      <Input
                        id="documentName"
                        placeholder="Название документа"
                        autoComplete="off"
                        autoCorrect="off"
                        disabled={vm.isLoading}
                        {...field}
                      />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />
              <FormField
                control={form.control}
                name="url"
                render={({ field }) => (
                  <FormItem className="flex flex-col space-y-3">
                    <Label htmlFor="url">Ссылка на файл</Label>
                    <FormControl>
                      <Input
                        id="url"
                        placeholder="Ссылка"
                        autoComplete="off"
                        autoCorrect="off"
                        disabled={vm.isLoading}
                        {...field}
                      />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />
              <DialogFooter>
                <DialogClose asChild>
                  <Button type="button" variant="secondary">
                    Отмена
                  </Button>
                </DialogClose>
                <Button type="submit">Загрузить</Button>
              </DialogFooter>
            </div>
          </form>
        </Form>
      </DialogContent>
    </Dialog>
  );
};

export default observer(UploadDocumentModal);
