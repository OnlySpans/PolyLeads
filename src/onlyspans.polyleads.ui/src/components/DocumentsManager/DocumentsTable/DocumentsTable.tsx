'use client';

import useGet from '@/hooks/useGet';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import { IDocumentsTableVM } from '@/components/DocumentsManager/DocumentsTable/DocumentsTableVM';
import React from 'react';
import { observer } from 'mobx-react-lite';

import {
  ColumnDef,
  ColumnFiltersState,
  flexRender,
  getCoreRowModel,
  getFilteredRowModel,
  getPaginationRowModel,
  getSortedRowModel,
  SortingState,
  useReactTable,
  VisibilityState,
} from '@tanstack/react-table';

import { Button } from '@/components/ui/button';
import {
  DropdownMenu,
  DropdownMenuCheckboxItem,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuSeparator,
  DropdownMenuTrigger,
} from '@/components/ui/dropdown-menu';
import { Input } from '@/components/ui/input';
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from '@/components/ui/table';
import { Checkbox } from '@/components/ui/checkbox';
import { ChevronsUpDown, Ellipsis, Settings2 } from 'lucide-react';
import moment from 'moment';

const data: Documents[] = [
  {
    name: 'AAA Electronic Concrete Cheese',
    createdAt: '2006-10-13T14:46:05.818Z',
    fileRecognitionStatus: 2,
    resource: 'Сайт Политеха',
    createdBy: 'Zoe',
  },
  {
    name: 'BBB Refined Plastic Pizza',
    createdAt: '2013-10-07T01:44:43.285Z',
    fileRecognitionStatus: 1,
    resource: 'Сайт Политеха',
    createdBy: 'Ryley',
  },
  {
    name: 'CCC Refined Cotton Gloves',
    createdAt: '1987-08-31T15:49:22.344Z',
    fileRecognitionStatus: 0,
    resource: 'Телеграм',
    createdBy: 'Lilian',
  },
  {
    name: 'DDD Luxurious Steel Chair',
    createdAt: '1995-08-22T22:47:55.552Z',
    fileRecognitionStatus: 4,
    resource: 'Сайт Политеха',
    createdBy: 'Alysha',
  },
  {
    name: 'AAA Electronic Concrete Cheese',
    createdAt: '2006-10-13T14:46:05.818Z',
    fileRecognitionStatus: 2,
    resource: 'Сайт Политеха',
    createdBy: 'Zoe',
  },
  {
    name: 'BBB Refined Plastic Pizza',
    createdAt: '2013-10-07T01:44:43.285Z',
    fileRecognitionStatus: 1,
    resource: 'Сайт Политеха',
    createdBy: 'Ryley',
  },
  {
    name: 'CCC Refined Cotton Gloves',
    createdAt: '1987-08-31T15:49:22.344Z',
    fileRecognitionStatus: 0,
    resource: 'Телеграм',
    createdBy: 'Lilian',
  },
  {
    name: 'DDD Luxurious Steel Chair',
    createdAt: '1995-08-22T22:47:55.552Z',
    fileRecognitionStatus: 4,
    resource: 'Сайт Политеха',
    createdBy: 'Alysha',
  },
  {
    name: 'AAA Electronic Concrete Cheese',
    createdAt: '2006-10-13T14:46:05.818Z',
    fileRecognitionStatus: 2,
    resource: 'Сайт Политеха',
    createdBy: 'Zoe',
  },
  {
    name: 'BBB Refined Plastic Pizza',
    createdAt: '2013-10-07T01:44:43.285Z',
    fileRecognitionStatus: 1,
    resource: 'Сайт Политеха',
    createdBy: 'Ryley',
  },
  {
    name: 'CCC Refined Cotton Gloves',
    createdAt: '1987-08-31T15:49:22.344Z',
    fileRecognitionStatus: 0,
    resource: 'Телеграм',
    createdBy: 'Lilian',
  },
  {
    name: 'DDD Luxurious Steel Chair',
    createdAt: '1995-08-22T22:47:55.552Z',
    fileRecognitionStatus: 4,
    resource: 'Сайт Политеха',
    createdBy: 'Alysha',
  },
];


export type Documents = {
  name: string;
  createdAt: string;
  fileRecognitionStatus: number;
  resource: string;
  createdBy: string;
}



export const columns: ColumnDef<Documents>[] = [
  {
    id: "select",
    header: ({ table }) => (
      <Checkbox
        checked={
          table.getIsAllPageRowsSelected() ||
          (table.getIsSomePageRowsSelected() && "indeterminate")
        }
        onCheckedChange={(value) => table.toggleAllPageRowsSelected(!!value)}
        aria-label="Select all"
      />
    ),
    cell: ({ row }) => (
      <Checkbox
        checked={row.getIsSelected()}
        onCheckedChange={(value) => row.toggleSelected(!!value)}
        aria-label="Select row"
      />
    ),
    enableSorting: false,
    enableHiding: false,
  },
  
  {
    accessorKey: "name",
    header: ({ column }) => {
      return (
        <Button
          variant="ghost"
          onClick={() => column.toggleSorting(column.getIsSorted() === "asc")}
        >
          Название
          <ChevronsUpDown className="ml-2 h-4 w-4" />
        </Button>
      )
    },
    cell: ({ row }) =>(row.getValue("name")),
  },
  {
    accessorKey: "createdAt",
    header: ({ column }) => {
      return (
        <Button
          variant="ghost"
          onClick={() => column.toggleSorting(column.getIsSorted() === "asc")}
        >
          Время добавления
          <ChevronsUpDown className="ml-2 h-4 w-4" />
        </Button>
      )
    },
    cell: ({ row }) => (
      moment(row.getValue("createdAt")).format('hh:mm - DD.MM.YYYY')
    )
  },
  {
    accessorKey: "fileRecognitionStatus",
    header: ({ column }) => {
      return (
        <Button
          variant="ghost"
          onClick={() => column.toggleSorting(column.getIsSorted() === "asc")}
        >
          Статус распознования
          <ChevronsUpDown className="ml-2 h-4 w-4" />
        </Button>
      )
    },
    cell: ({ row }) => (
      row.getValue("fileRecognitionStatus")
    ),
  },
  {
    accessorKey: "resource",
    header: ({ column }) => {
      return (
        <Button
          variant="ghost"
          onClick={() => column.toggleSorting(column.getIsSorted() === "asc")}
        >
          Ресурс
          <ChevronsUpDown className="ml-2 h-4 w-4" />
        </Button>
      )
    },
    cell: ({ row }) => (
      row.getValue("resource")
    ),
  },
  {
    accessorKey: "createdBy",
    header: "Пользователь",
    cell: ({ row }) => (
      row.getValue("createdBy")
    ),
  },
  {
    id: "actions",
    enableHiding: false,
    cell: ({ row }) => {
      const document = row.original

      return (
        <DropdownMenu>
          <DropdownMenuTrigger asChild>
            <Button variant="ghost" className="h-8 w-8 p-0">
              <Ellipsis className="h-4 w-4" />
            </Button>
          </DropdownMenuTrigger>
          <DropdownMenuContent align="end">
            <DropdownMenuLabel>Действия</DropdownMenuLabel>
            <DropdownMenuItem
              onClick={() => navigator.clipboard.writeText(document.name)}
            >
              Копировать название документа
            </DropdownMenuItem>
            <DropdownMenuSeparator />
            <DropdownMenuItem>Что-то еще</DropdownMenuItem>
            <DropdownMenuItem>Что-то еще</DropdownMenuItem>
          </DropdownMenuContent>
        </DropdownMenu>
      )
    },
  },
]



interface IDocumentsTableProps {}
const DocumentsTable: React.FC<IDocumentsTableProps>  = () => {
  const vm = useGet<IDocumentsTableVM>(ServiceSymbols.IDocumentsTableVM);

  const documents = vm.data;

  const [sorting, setSorting] = React.useState<SortingState>([])
  const [columnFilters, setColumnFilters] = React.useState<ColumnFiltersState>(
    []
  )
  const [columnVisibility, setColumnVisibility] =
    React.useState<VisibilityState>({})
  const [rowSelection, setRowSelection] = React.useState({})

  const table = useReactTable({
    data,
    columns,
    onSortingChange: setSorting,
    onColumnFiltersChange: setColumnFilters,
    getCoreRowModel: getCoreRowModel(),
    getPaginationRowModel: getPaginationRowModel(),
    getSortedRowModel: getSortedRowModel(),
    getFilteredRowModel: getFilteredRowModel(),
    onColumnVisibilityChange: setColumnVisibility,
    onRowSelectionChange: setRowSelection,
    state: {
      sorting,
      columnFilters,
      columnVisibility,
      rowSelection,
    },
  })

  return (
    <div className='w-full space-y-4'>
      <div className='flex items-center justify-between'>
        <div className='flex flex-1 items-center space-x-2'>
          <Input
            placeholder='Искать по названию'
            value={(table.getColumn('name')?.getFilterValue() as string) ?? ''}
            onChange={(event) =>
              table.getColumn('name')?.setFilterValue(event.target.value)
            }
            className='h-8 w-[150px] lg:w-[250px]'
          />
          <Button variant='outline' className='h-8 px-4'>
            Добавить файл
          </Button>
        </div>

        <DropdownMenu>
          <DropdownMenuTrigger asChild>
            <Button variant='outline' className='h-8 px-4'>
              <Settings2 className='mr-2 size-4' />
              Вид
            </Button>
          </DropdownMenuTrigger>
          <DropdownMenuContent align='end'>
            {table
              .getAllColumns()
              .filter((column) => column.getCanHide())
              .map((column) => {
                return (
                  <DropdownMenuCheckboxItem
                    key={column.id}
                    className='capitalize'
                    checked={column.getIsVisible()}
                    onCheckedChange={(value) =>
                      column.toggleVisibility(value)
                    }
                  >
                    {column.id}
                  </DropdownMenuCheckboxItem>
                );
              })}
          </DropdownMenuContent>
        </DropdownMenu>
      </div>

      <div className='rounded-md border'>
        <Table>
          <TableHeader>
            {table.getHeaderGroups().map((headerGroup) => (
              <TableRow key={headerGroup.id}>
                {headerGroup.headers.map((header) => {
                  return (
                    <TableHead key={header.id}>
                      {header.isPlaceholder
                        ? null
                        : flexRender(
                            header.column.columnDef.header,
                            header.getContext(),
                          )}
                    </TableHead>
                  );
                })}
              </TableRow>
            ))}
          </TableHeader>
          <TableBody>
            {table.getRowModel().rows?.length ? (
              table.getRowModel().rows.map((row) => (
                <TableRow
                  key={row.id}
                  data-state={row.getIsSelected() && 'selected'}
                >
                  {row.getVisibleCells().map((cell) => (
                    <TableCell key={cell.id}>
                      {flexRender(
                        cell.column.columnDef.cell,
                        cell.getContext(),
                      )}
                    </TableCell>
                  ))}
                </TableRow>
              ))
            ) : (
              <TableRow>
                <TableCell
                  colSpan={columns.length}
                  className='h-24 text-center'
                >
                  No results.
                </TableCell>
              </TableRow>
            )}
          </TableBody>
        </Table>
      </div>
      <div className='flex items-center justify-end space-x-2 py-4'>
        <div className='flex-1 text-sm text-muted-foreground'>
          {table.getFilteredSelectedRowModel().rows.length} из{' '}
          {table.getFilteredRowModel().rows.length} документов выбрано.
        </div>
        <div className='space-x-2'>
          <Button
            variant='outline'
            size='sm'
            onClick={() => table.previousPage()}
            disabled={!table.getCanPreviousPage()}
          >
            Назад
          </Button>
          <Button
            variant='outline'
            size='sm'
            onClick={() => table.nextPage()}
            disabled={!table.getCanNextPage()}
          >
            Вперед
          </Button>
        </div>
      </div>
    </div>
  );
}

export default observer(DocumentsTable);