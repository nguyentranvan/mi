import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { LayoutService } from './service/app.layout.service';

@Component({
    selector: 'app-menu',
    templateUrl: './app.menu.component.html'
})
export class AppMenuComponent implements OnInit {

    model: any[] = [];

    constructor(public layoutService: LayoutService) { }

    ngOnInit() {
        this.model = [
            {
                label: 'Không gian làm việc',
                items: [
                    { label: 'Báo cáo', icon: 'pi pi-fw pi-home', routerLink: ['/admin'] }
                ]
            },
            {
                label: 'Khóa học',
                items: [
                    { label: 'Danh mục', icon: 'pi pi-fw pi-bars', routerLink: ['/demo/uikit/input'] },
                    { label: 'Mẫu chứng chỉ', icon: 'pi pi-fw pi-verified', routerLink: ['/admin/certificate'] },
                    { label: 'Quản lý khóa học', icon: 'pi pi-fw pi-id-card', routerLink: ['/demo/uikit/formlayout'] },
                    { label: 'Cấp chứng chỉ', icon: 'pi pi-fw pi-check-circle', routerLink: ['/demo/uikit/floatlabel'] }
                    // { label: 'Invalid State', icon: 'pi pi-fw pi-exclamation-circle', routerLink: ['/demo/uikit/invalidstate'] },
                    // { label: 'Button', icon: 'pi pi-fw pi-box', routerLink: ['/demo/uikit/button'] },
                    // { label: 'Table', icon: 'pi pi-fw pi-table', routerLink: ['/demo/uikit/table'] },
                    // { label: 'List', icon: 'pi pi-fw pi-list', routerLink: ['/demo/uikit/list'] },
                    // { label: 'Tree', icon: 'pi pi-fw pi-share-alt', routerLink: ['/demo/uikit/tree'] },
                    // { label: 'Panel', icon: 'pi pi-fw pi-tablet', routerLink: ['/demo/uikit/panel'] },
                    // { label: 'Overlay', icon: 'pi pi-fw pi-clone', routerLink: ['/demo/uikit/overlay'] },
                    // { label: 'Media', icon: 'pi pi-fw pi-image', routerLink: ['/demo/uikit/media'] },
                    // { label: 'Menu', icon: 'pi pi-fw pi-bars', routerLink: ['/demo/uikit/menu'], routerLinkActiveOptions: { paths: 'subset', queryParams: 'ignored', matrixParams: 'ignored', fragment: 'ignored' } },
                    // { label: 'Message', icon: 'pi pi-fw pi-comment', routerLink: ['/demo/uikit/message'] },
                    // { label: 'File', icon: 'pi pi-fw pi-file', routerLink: ['/demo/uikit/file'] },
                    // { label: 'Chart', icon: 'pi pi-fw pi-chart-bar', routerLink: ['/demo/uikit/charts'] },
                    // { label: 'Misc', icon: 'pi pi-fw pi-circle', routerLink: ['/demo/uikit/misc'] }
                ]
            },
            {
                label: 'Đánh giá',
                items: [
                    {
                        label: 'Danh mục', icon: 'pi pi-fw pi-bars',
                        items: [
                            {label: 'Danh mục câu hỏi', icon: 'pi pi-fw pi-bookmark', routerLink: ['/demo/uikit/formlayout']},
                            {label: 'Danh mục đánh giá', icon: 'pi pi-fw pi-bookmark', routerLink: ['/demo/uikit/formlayout']},
                        ]
                    },
                    { label: 'Ngân hàng câu hỏi', icon: 'pi pi-fw pi-question-circle', routerLink: ['/demo/utilities/icons'] },
                    { label: 'Kỳ đánh giá', icon: 'pi pi-fw pi-desktop', url: ['https://www.primefaces.org/primeflex/'], target: '_blank' },
                ]
            },
            {
                label: 'Hệ thống',
                items: [
                    { label: 'Cơ cấu tổ chức', icon: 'pi pi-fw pi-sitemap', routerLink: ['/demo/blocks'] },
                    { label: 'Tài khoản', icon: 'pi pi-fw pi-user',  routerLink: ['/demo/blocks']  },
                    { label: 'Nhật ký hệ thống', icon: 'pi pi-fw pi-calendar',  routerLink: ['/demo/blocks'] },
                    { label: 'Cấu hình hệ thống', icon: 'pi pi-fw pi-calendar',  routerLink: ['/demo/blocks'] }
                ]
            }
            //,
            // {
            //     label: 'Pages',
            //     icon: 'pi pi-fw pi-briefcase',
            //     items: [
            //         {
            //             label: 'Auth',
            //             icon: 'pi pi-fw pi-user',
            //             items: [
            //                 {
            //                     label: 'Login',
            //                     icon: 'pi pi-fw pi-sign-in',
            //                     routerLink: ['/auth/login']
            //                 },
            //                 {
            //                     label: 'Error',
            //                     icon: 'pi pi-fw pi-times-circle',
            //                     routerLink: ['/auth/error']
            //                 },
            //                 {
            //                     label: 'Access Denied',
            //                     icon: 'pi pi-fw pi-lock',
            //                     routerLink: ['/auth/access']
            //                 }
            //             ]
            //         },
            //         {
            //             label: 'Crud',
            //             icon: 'pi pi-fw pi-pencil',
            //             routerLink: ['/demo/pages/crud']
            //         },
            //         {
            //             label: 'Timeline',
            //             icon: 'pi pi-fw pi-calendar',
            //             routerLink: ['/demo/pages/timeline']
            //         },
            //         {
            //             label: 'Not Found',
            //             icon: 'pi pi-fw pi-exclamation-circle',
            //             routerLink: ['/demo/notfound']
            //         },
            //         {
            //             label: 'Empty',
            //             icon: 'pi pi-fw pi-circle-off',
            //             routerLink: ['/demo/pages/empty']
            //         },
            //     ]
            // },
            // {
            //     label: 'Hierarchy',
            //     items: [
            //         {
            //             label: 'Submenu 1', icon: 'pi pi-fw pi-bookmark',
            //             items: [
            //                 {
            //                     label: 'Submenu 1.1', icon: 'pi pi-fw pi-bookmark',
            //                     items: [
            //                         { label: 'Submenu 1.1.1', icon: 'pi pi-fw pi-bookmark' },
            //                         { label: 'Submenu 1.1.2', icon: 'pi pi-fw pi-bookmark' },
            //                         { label: 'Submenu 1.1.3', icon: 'pi pi-fw pi-bookmark' },
            //                     ]
            //                 },
            //                 {
            //                     label: 'Submenu 1.2', icon: 'pi pi-fw pi-bookmark',
            //                     items: [
            //                         { label: 'Submenu 1.2.1', icon: 'pi pi-fw pi-bookmark' }
            //                     ]
            //                 },
            //             ]
            //         },
            //         {
            //             label: 'Submenu 2', icon: 'pi pi-fw pi-bookmark',
            //             items: [
            //                 {
            //                     label: 'Submenu 2.1', icon: 'pi pi-fw pi-bookmark',
            //                     items: [
            //                         { label: 'Submenu 2.1.1', icon: 'pi pi-fw pi-bookmark' },
            //                         { label: 'Submenu 2.1.2', icon: 'pi pi-fw pi-bookmark' },
            //                     ]
            //                 },
            //                 {
            //                     label: 'Submenu 2.2', icon: 'pi pi-fw pi-bookmark',
            //                     items: [
            //                         { label: 'Submenu 2.2.1', icon: 'pi pi-fw pi-bookmark' },
            //                     ]
            //                 },
            //             ]
            //         }
            //     ]
            // },
            // {
            //     label: 'Get Started',
            //     items: [
            //         {
            //             label: 'Documentation', icon: 'pi pi-fw pi-question', routerLink: ['/demo/documentation']
            //         },
            //         {
            //             label: 'View Source', icon: 'pi pi-fw pi-search', url: ['https://github.com/primefaces/sakai-ng'], target: '_blank'
            //         }
            //     ]
            // }
        ];
    }
}
