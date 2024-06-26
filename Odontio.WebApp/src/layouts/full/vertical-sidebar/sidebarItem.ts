import { SettingsIcon, AffiliateIcon, UsersIcon, UserIcon } from 'vue-tabler-icons';

export interface menu {
  header?: string;
  title?: string;
  icon?: object;
  to?: string | object;
  divider?: boolean;
  chip?: string;
  chipColor?: string;
  chipVariant?: string;
  chipIcon?: string;
  children?: menu[];
  disabled?: boolean;
  type?: string;
  subCaption?: string;
}

const AdminNavItems: menu[] = [
  {
    title: 'Worskpaces',
    icon: AffiliateIcon,
    to: '/admin/workspaces'
  },
  {
    title: 'Users',
    icon: UsersIcon,
    to: '/admin/users'
  }
];

const WorkspaceNavItems: menu[] = [
  {
    title: 'Pacientes',
    icon: UsersIcon,
    to: { name: 'patient-list' }
  },
  {
    title: 'Configuración',
    icon: SettingsIcon,
    children: [
      {
        title: 'Tratamientos',
        to: { name: 'treatment-list' }
      },
      {
        title: 'Enfermedades',
        to: { name: 'disease-list' }
      },
      {
        title: 'Cuestionario',
        to: { name: 'medical-condition-list' }
      }
    ]
  }
];

const PatientNavItems: menu[] = [
  {
    title: 'Pacientes',
    icon: UsersIcon,
    to: { name: 'patient-list' },
    children: [
      {
        title: 'Ficha Médica',
        to: { name: 'patient-detail' }
      },
      {
        title: 'Diagnósticos',
        to: { name: 'disease-list' }
      },
      {
        title: 'Tratamientos',
        to: { name: 'medical-condition-list' }
      },
      {
        title: 'Todos',
        to: { name: 'patient-list' }
      },
    ]
  },
  {
    title: 'Configuración',
    icon: SettingsIcon,
    children: [
      {
        title: 'Tratamientos',
        to: { name: 'treatment-list' }
      },
      {
        title: 'Enfermedades',
        to: { name: 'disease-list' }
      },
      {
        title: 'Cuestionario',
        to: { name: 'medical-condition-list' }
      }
    ]
  }
];

export { AdminNavItems, WorkspaceNavItems, PatientNavItems };
