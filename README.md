![pearblossom](https://raw.githubusercontent.com/angela-1/pearblossom/master/pearblossom/images/pearblossom.png)

# 梨花 - 文档处理工具集

代号：pearblossom

版本 3.0。

## 视觉

标志为一个书签。
颜色：
- hex #F66D31
- rgb 246,109,49


## 功能
 - 转换 `*.docx/*.doc` 为 `*.pdf/*.txt` 文件
 - 合并一个文件夹下的文件 `*.docx/*.doc/*.pdf` 为一个 `*.pdf` 文件
 - 提取带有书签的 `*.pdf` 文件生成目录
 - 给 `*.pdf` 文件添加页码，可选两种页码格式
 - 给总页数数为奇数页的 `*.pdf` 文件添加一个空白页变成偶数页

## 使用方法


### 合并文件


1. 选择要合并的文件所在文件夹
2. 点击“合并文件”按钮，合并文件
3. 结果存放在文件夹同级目录下



### 转换格式


1. 选择要转换的文件所有文件夹或单个文件或多个文件
2. 点击“转换格式”选择目标文件格式 `*.docx/*.pdf/*.txt`
3. 结果存放在源文件相同目录下



### 提取目录

1. 点击“打开”选择带有目录的 `*.pdf` 文件，或者拖动到程序窗口内。提示框显示已选文件的路径。
2. 点击“提取目录”按钮导出目录，默认为 `*.docx` 格式。点击下拉箭头可选择 `*.txt` 格式。
3. 导出成功。提示框显示导出目录的路径。
4. 在 Word 中修改格式以符合要求。（导出为 `*.docx` 格式）


### 添加页码

1. 点击“打开”选择带有目录的 `*.pdf` 文件，或者拖动到程序窗口内。提示框显示已选文件的路径。
2. 点击“添加页码”，生成一个带有 `_pagenumber` 后缀的 `*_pagenumber.pdf` 文件。
3. 成功。提示框显示生成文件的路径。

### 加偶数页

1. 点击“打开”选择带有目录的 `*.pdf` 文件，或者拖动到程序窗口内。提示框显示已选文件的路径。
2. 点击“加偶数页”，生成一个带有 `_even` 后缀的 `*_even.pdf` 文件。
3. 成功。提示框显示生成文件的路径。


## 制作汇编材料

### 准备工作

- Adobe Acrobat
- Word
- Pearblossom







