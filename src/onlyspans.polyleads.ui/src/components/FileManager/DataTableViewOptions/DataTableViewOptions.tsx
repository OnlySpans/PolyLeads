import React from 'react';
import { Settings2 } from 'lucide-react';
import { Button } from '@/components/ui/button';
import { Table } from '@tanstack/react-table';
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuLabel,
  DropdownMenuSeparator,
  DropdownMenuTrigger,
} from '@/components/ui/dropdown-menu';

interface IDataTableViewOptionsProps<TData> {
  table: Table<TData>;
}

const DataTableViewOptions: React.FC<any> = <TData extends any>({
  table,
}: IDataTableViewOptionsProps<TData>) => {
  return (
    <>
      <DropdownMenu>
        <DropdownMenuTrigger asChild>
          <Button variant='outline' className='h-8 px-4'>
            <Settings2 className='mr-2 size-4' />
            Вид
          </Button>
        </DropdownMenuTrigger>
        <DropdownMenuContent align='end' className='w-[150px]'>
          <DropdownMenuLabel>Toggle columns</DropdownMenuLabel>
          <DropdownMenuSeparator />
          {/*{table*/}
          {/*  .getAllColumns()*/}
          {/*  .filter(*/}
          {/*    (column) =>*/}
          {/*      typeof column.accessorFn !== 'undefined' && column.getCanHide(),*/}
          {/*  )*/}
          {/*  .map((column) => {*/}
          {/*    return (*/}
          {/*      <DropdownMenuCheckboxItem*/}
          {/*        key={column.id}*/}
          {/*        className='capitalize'*/}
          {/*        checked={column.getIsVisible()}*/}
          {/*        onCheckedChange={(value) => column.toggleVisibility(!!value)}*/}
          {/*      >*/}
          {/*        {column.id}*/}
          {/*      </DropdownMenuCheckboxItem>*/}
          {/*    );*/}
          {/*  })}*/}
        </DropdownMenuContent>
      </DropdownMenu>
    </>
  );
};

export default DataTableViewOptions;
