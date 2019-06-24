import React from 'react';
import { Tag, Icon, Input, Tooltip } from 'antd';

export interface ITagInputProps {
    value?: Array<string>;
    onChange?: (value: any) => void;
    newText?: string;
    longTagLength?: number;
    inputStyle?: React.CSSProperties
}

export interface ITagInputStates {
    tags: Array<string>;
    inputValue: string;
    inputVisible?: boolean;
}

class TagInput extends React.Component<ITagInputProps, ITagInputStates> {

    static getDerivedStateFromProps(nextProps: ITagInputProps) {
        // Should be a controlled component.
        if ('value' in nextProps) {
            return {
                ...(nextProps.value || []),
            };
        }
        return null;
    }

    static defaultProps: ITagInputProps = {
        newText: "New Tag",
        longTagLength: 20,
        inputStyle: { width: '100px' }
    }

    constructor(props: ITagInputProps) {
        super(props);

        const value = props.value || []
        this.state = {
            tags: value || [],
            inputValue: '',
        };
    }

    handleClose = (removedTag: string) => {
        const tags = this.state.tags.filter(tag => tag !== removedTag);
        console.log(tags);
        this.setState({ tags });
    };

    showInput = () => {
        this.setState({ inputVisible: true }, () => this.input !== null && this.input.focus());
    };

    handleInputChange = (e: any) => {
        this.setState({ inputValue: e.target.value });
    };

    handleInputConfirm = () => {
        const { onChange } = this.props;
        const { inputValue } = this.state;
        let { tags } = this.state;
        if (inputValue && tags.indexOf(inputValue) === -1) {
            tags = [...tags, inputValue];
        }

        this.setState({
            tags,
            inputVisible: false,
            inputValue: '',
        });

        onChange && onChange([...tags]);
    };

    saveInputRef = (input: Input | null) => (this.input = input);
    input: Input | null = null;

    render() {
        const { tags, inputVisible, inputValue } = this.state;
        const { newText, longTagLength, inputStyle } = this.props;

        return (
            <div>
                {tags.map((tag, index) => {
                    const isLongTag = (longTagLength && longTagLength > 0) && tag.length > (longTagLength || 20);
                    const tagElem = (
                        <Tag key={tag} closable={true} onClose={() => this.handleClose(tag)}>
                            {isLongTag ? `${tag.slice(0, (longTagLength || 20))}...` : tag}
                        </Tag>
                    );
                    return isLongTag ? (
                        <Tooltip title={tag} key={tag}>
                            {tagElem}
                        </Tooltip>
                    ) : (
                            tagElem
                        );
                })}
                {inputVisible && (
                    <Input
                        ref={this.saveInputRef}
                        type="text"
                        size="small"
                        style={inputStyle}
                        value={inputValue}
                        onChange={this.handleInputChange}
                        onBlur={this.handleInputConfirm}
                        onPressEnter={this.handleInputConfirm}
                    />
                )}
                {!inputVisible && (
                    <Tag onClick={this.showInput} style={{ background: '#fff', borderStyle: 'dashed' }}>
                        <Icon type="plus" /> {newText}
                    </Tag>
                )}
            </div>
        );
    }
}

export default TagInput;