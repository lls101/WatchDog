#!/bin/sh

# 定义应用配置（名称、JSON路径、描述）
declare -A apps=(
["WFDBTool"]="AppEntities/WFDBTool.json:数据库配置工具"
["Hmi.Designer"]="AppEntities/Hmi.Designer.json:作图支持系统"
["Hmi.Protector"]="AppEntities/Hmi.Protector.json:微机防误闭锁系统"
)

# 获取脚本所在目录的父目录
script_dir=$(dirname "$(readlink -f "$0")")
parent_dir=$(dirname "$script_dir")

# 创建AppEntities目录
mkdir -p "${script_dir}/AppEntities"

# 查找函数：在父目录查找应用文件
find_app_in_parent() {
local app_name=$1
local target_path="${parent_dir}/${app_name}"

if [ -f "${target_path}" ]; then
echo "${target_path}"
return 0
else
echo "错误：在父目录 ${parent_dir} 中未找到 ${app_name}" >&2
return 1
fi
}

# 生成/更新JSON文件
generate_json() {
local app_name=$1
local json_path=$2
local description=$3
local app_path=$4

# JSON模板（注意换行符和缩进）
local json_content="{
\"AppName\": \"${app_name}\",
\"AppPath\": \"${app_path}\",
\"Description\": \"${description}\",
\"SysPaths\": null,
\"LibPaths\": null,
\"EnvVariables\": null,
\"IsAutoRunning\": false,
\"IsPTask\": false,
\"PTaskParm\": null
}"

# 写入文件（原子操作）
echo "${json_content}" > "${json_path}.tmp" && mv "${json_path}.tmp" "${json_path}"
echo "生成/更新文件：${json_path}"
}

# 主流程
exit_code=0
for app_key in "${!apps[@]}"; do
IFS=':' read -ra app_info <<< "${apps[$app_key]}"
    json_file="${app_info[0]}"
    description="${app_info[1]}"

    if app_path=$(find_app_in_parent "${app_key}"); then
        # 获取应用文件的父目录路径
        app_dir=$(dirname "$app_path")
        # 转义路径中的双引号
        escaped_path=$(echo "${app_dir}" | sed 's/"/\\"/g')
        
        # 生成完整JSON路径
        full_json_path="${script_dir}/${json_file}"
        
        # 执行生成操作
        if generate_json "${app_key}" "${full_json_path}" "${description}" "${escaped_path}"; then
            echo "成功处理 ${app_key}"
        else
            echo "错误：处理 ${app_key} 失败" >&2
exit_code=1
fi
else
exit_code=1
fi
done

exit ${exit_code}
